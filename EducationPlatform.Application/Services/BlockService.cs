using AutoMapper;
using EducationPlatform.Application.Interface;
using EducationPlatform.Domain.Entity;
using EducationPlatform.Infra.Data.Interfaces;
using Microsoft.Extensions.Configuration;

namespace EducationPlatform.Application.Service
{
    public class BlockService : ICRUDService<BlockOutput, BlockInput>
    {
        private readonly IConfiguration _configuration;
        private readonly ICRUDRepository<Block> _repository;
        private readonly IMapper _mapper;

        public BlockService(IConfiguration configuration, ICRUDRepository<Block> repository, IMapper mapper)
        {
            _configuration = configuration;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BlockOutput> FindById(int id)
        {
            Block BlockDb = await _repository.FindById(id);
            BlockOutput BlockMap = _mapper.Map<BlockOutput>(BlockDb);
            return BlockMap;
        }

        public async Task<List<BlockOutput>> GetAll()
        {
            List<Block> BlockDb = await _repository.GetAll();
            List<BlockOutput> BlockMap = _mapper.Map<List<BlockOutput>>(BlockDb);
            return BlockMap;
        }

        public async Task<BlockOutput> Create(BlockInput create)
        {
            //Create
            Block BlockCreate = _mapper.Map<Block>(create);
            Block BlockDb = await _repository.Create(BlockCreate);
            
            //Find
            var BlockDb_Include = await _repository.FindById(BlockDb.Id);

            BlockOutput BlockMap = _mapper.Map<BlockOutput>(BlockDb);

            return BlockMap;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var BlockToDelete = await _repository.FindById(id);
                if (BlockToDelete is null)
                {
                    throw new Exception("Blocka informada não existe ou já foi deletado");
                }
                var result = await _repository.Delete(id);               
                return result;
            }
            catch (Exception msg)
            {
                throw new Exception(msg.Message);
            }            
        }

        public async Task<BlockOutput> Update(int id, BlockInput update)
        {
            Block buscarDb = await _repository.FindById(id);
            if (buscarDb == null)
            {
                throw new Exception("Atendimento não localizado");
            }         
            
            Block BlockEditar = _mapper.Map<Block>(update);
            BlockEditar.Id = id;
            Block BlockDb = await _repository.Update(BlockEditar);

            BlockOutput BlockMap = _mapper.Map<BlockOutput>(BlockDb);

            return BlockMap;
        }
    }
}
