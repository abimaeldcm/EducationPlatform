using EducationPlatform.Infra.Data.Interfaces;
using EducationPlatform.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace EducationPlatform.Infra.Data.Repository
{
    public class BlockRepository : ICRUDRepository<Block>
    {
        //Buscar pr período

        private readonly EducationDbContext _context;

        public BlockRepository(EducationDbContext context)
        {
            _context = context;
        }

        public async Task<Block> FindById(int id)
        {
            return await _context.Blocks
                .AsNoTracking()
                .Include(x => x.Lesson)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Block>> GetAll()
        {
            return await _context.Blocks.Include(x => x.Lesson).ToListAsync();
        }

        public async Task<Block> Create(Block create)
        {
            await _context.Blocks.AddAsync(create);
            await _context.SaveChangesAsync();

            return create;
        }

        public async Task<bool> Delete(int id)
        {
            var consutDb = await FindById(id);
            _context.Blocks.Remove(consutDb);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Block> Update(Block update)
        {
            try
            {
                var existingBlock = await _context.Blocks.FindAsync(update.Id);
                if (existingBlock == null)
                {
                    throw new ArgumentException("Block not found.");
                }

                _context.Entry(existingBlock).CurrentValues.SetValues(update);
                await _context.SaveChangesAsync();

                return existingBlock;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
