using EducationPlatform.Infra.Data.Interfaces;
using EducationPlatform.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace EducationPlatform.Infra.Data.Repository
{
    public class LessonRepository : ICRUDRepository<Lesson>
    {

        private readonly EducationDbContext _context;

        public LessonRepository(EducationDbContext context)
        {
            _context = context;
        }

        public async Task<Lesson> Create(Lesson create)
        {
            await _context.Lessons.AddAsync(create);
            await _context.SaveChangesAsync();
            return create;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var emailDb = await FindById(id);
                _context.Lessons.Remove(emailDb);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao realizar a deleção!");
            }
        }

        public async Task<Lesson> FindById(int id)
        {
            return await _context.Lessons
                            .AsNoTracking()
                            .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Lesson>> FindByText(string query)
        {
            return null;
        }

        public async Task<List<Lesson>> GetAll()
        {
            var emailDb = await _context.Lessons.ToListAsync();
            await _context.SaveChangesAsync();
            return emailDb;
        }

        public async Task<Lesson> Update(Lesson update)
        {
            var emailDb = FindById(update.Id);
            if (emailDb != null)
            {
                _context.Lessons.Update(update);
                await _context.SaveChangesAsync();
                return update;
            }
            return null;

        }
    }
}
