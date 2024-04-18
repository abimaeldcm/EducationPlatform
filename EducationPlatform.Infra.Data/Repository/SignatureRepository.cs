using EducationPlatform.Infra.Data.Interfaces;
using EducationPlatform.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace EducationPlatform.Infra.Data.Repository
{
    public class SignatureRepository : ICRUDRepository<Signature>
    {
        private readonly EducationDbContext _context;

        public SignatureRepository(EducationDbContext context)
        {
            _context = context;
        }

        public async Task<Signature> FindById(int id)
        {
            return await _context.Signatures.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<List<Signature>> GetAll()
        {
            return await _context.Signatures.ToListAsync();
        }

        public async Task<Signature> Create(Signature create)
        {
            await _context.Signatures.AddAsync(create);
            await _context.SaveChangesAsync();

            return create;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var SignatureDb = await FindById(id);
                _context.Signatures.Remove(SignatureDb);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao realizar a deleção!");
            }

        }

        public async Task<Signature> Update(Signature update)
        {
            _context.Signatures.Update(update);
            await _context.SaveChangesAsync();
            return update;
        }

    }
}
