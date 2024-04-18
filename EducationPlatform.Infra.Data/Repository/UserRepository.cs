using EducationPlatform.Infra.Data.Interfaces;
using EducationPlatform.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace EducationPlatform.Infra.Data.Repository
{
    public class UserEntityRepository : ICRUDRepository<UserEntity>, ILoginRepository
    {
        private readonly EducationDbContext _context;

        public UserEntityRepository(EducationDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity> FindLogin(string CPF, string password)
        {
            try
            {
                var loginDb = await _context.Users.FirstOrDefaultAsync(x => x.CPF == CPF && x.Password == password);
                return loginDb is null ? throw new Exception("Login ou Senha inválidos") : loginDb;

            }
            catch (Exception msg)
            {

                throw;
            }
        }

        public async Task<UserEntity> FindById(int id)
        {
            var servicoDb = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (servicoDb is null)
            {
                throw new Exception("Id Não existe no banco de dados.");
            }
            return servicoDb;
        }

        public async Task<List<UserEntity>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserEntity> Create(UserEntity create)
        {
            await _context.Users.AddAsync(create);
            await _context.SaveChangesAsync();

            return create;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var UserEntityDb = await FindById(id);
                _context.Users.Remove(UserEntityDb);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<UserEntity> Update(UserEntity update)
        {
            _context.Users.Update(update);
            await _context.SaveChangesAsync();
            return update;
        }
    }
}
