using EducationPlatform.Infra.Data.Interfaces;
using EducationPlatform.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using EducationPlatform.Domain.Entity.EntityRelational;

namespace EducationPlatform.Infra.Data.Repository
{
    public class UserSignatureRepository : ICRUDRepository<UserSignature>, IUserSignatureRepository
    {
        private readonly EducationDbContext _context;

        public UserSignatureRepository(EducationDbContext context)
        {
            _context = context;
        }

        public async Task<UserSignature> FindById(int id)
        {
            return await _context.UserSignatures
                .AsNoTracking()
                .Include(x => x.User)
                .Include(x => x.Signature)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<UserSignature>> GetAll()
        {
            return await _context.UserSignatures.ToListAsync();
        }

        public async Task<UserSignature> Create(UserSignature create)
        {
            await _context.UserSignatures.AddAsync(create);
            await _context.SaveChangesAsync();

            return create;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var SignatureDb = await FindById(id);
                _context.UserSignatures.Remove(SignatureDb);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao realizar a deleção!");
            }

        }

        public async Task<UserSignature> Update(UserSignature update)
        {
            _context.UserSignatures.Update(update);
            await _context.SaveChangesAsync();
            return update;
        }

        public async Task<UserSignature> FindByUser(int id)
        {
            return await _context.UserSignatures
                .Where(x => x.UserId == id)
                .Include(x => x.User)
                .Include(x => x.Signature)
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
