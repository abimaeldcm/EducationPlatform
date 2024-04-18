using EducationPlatform.Infra.Data.Interfaces;
using EducationPlatform.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EducationPlatform.Infra.Data.Repository
{
    public class CourseRepository : ICRUDRepository<Course>
    {
        private readonly EducationDbContext _context;
        private readonly ClaimsPrincipal _userClaims;

        public CourseRepository(EducationDbContext context, ClaimsPrincipal userClaims)
        {
            _context = context;
            _userClaims = userClaims;
        }

        public async Task<Course> FindById(int id)
        {
            return await _context.Courses.AsNoTracking().Include(x => x.Block).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Course>> GetAll()
        {
            try
            {
                int.TryParse(_userClaims.FindFirst("UserSignature")?.Value, out int result);

                return await _context.Courses.Where(x => x.SignatureId == result).Include(x => x.Block).ToListAsync();

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
