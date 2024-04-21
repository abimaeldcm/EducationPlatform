using EducationPlatform.Infra.Data.Interfaces;
using EducationPlatform.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using EducationPlatform.Domain.Entity.Enum;

namespace EducationPlatform.Infra.Data.Repository
{
    public class CourseRepository : ICRUDRepository<Course>
    {
        private readonly EducationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CourseRepository(EducationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Course> FindById(int id)
        {
            return await _context.Courses.AsNoTracking().Include(x => x.Block).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Course>> GetAll()
        {
            try
            {
                var user = _httpContextAccessor.HttpContext.User;
                var userSignatureClaim = user.FindFirst("UserSignature");
                var userClaimRole = user.FindFirst(c => c.Type == ClaimTypes.Role).Value;

                if (userClaimRole is not null && userClaimRole == EAccessLevel.Manager.ToString())
                {
                    return _context.Courses.ToList();
                }
                else if (userSignatureClaim != null && int.TryParse(userSignatureClaim.Value, out int userSignatureId))
                {
                    return await _context.Courses.Where(x => x.SignatureId == userSignatureId).Include(x => x.Block).ToListAsync();

                }

                return new List<Course>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Course> Create(Course create)
        {
            await _context.Courses.AddAsync(create);
            await _context.SaveChangesAsync();

            return create;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var patientDb = await FindById(id);
                _context.Courses.Remove(patientDb);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao realizar a deleção!");
            }

        }

        public async Task<Course> Update(Course update)
        {
            _context.Courses.Update(update);
            await _context.SaveChangesAsync();
            return update;
        }
    }
}
