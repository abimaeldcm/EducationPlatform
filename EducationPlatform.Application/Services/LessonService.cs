using AutoMapper;
using EducationPlatform.Application.Interface;
using EducationPlatform.Domain.Entity;
using EducationPlatform.Infra.Data.Interfaces;

namespace EducationPlatform.Application.Services
{
    public class LessonService : ICRUDService<LessonOutput, LessonInput>
    {
        private readonly ICRUDRepository<Lesson> _repository;
        private readonly IMapper _mapper;

        public LessonService(ICRUDRepository<Lesson> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<LessonOutput> FindById(int id)
        {
            Lesson LessonDb = await _repository.FindById(id);
            LessonOutput LessonMap = _mapper.Map<LessonOutput>(LessonDb);
            return LessonMap;
        }

        public async Task<List<LessonOutput>> GetAll()
        {
            List<Lesson> LessonDb = await _repository.GetAll();
            List<LessonOutput> LessonMap = _mapper.Map<List<LessonOutput>>(LessonDb);
            return LessonMap;
        }

        public async Task<LessonOutput> Create(LessonInput create)
        {
            Lesson LessonCadastro = _mapper.Map<Lesson>(create);
            Lesson LessonDb = await _repository.Create(LessonCadastro);
            LessonOutput LessonMap = _mapper.Map<LessonOutput>(LessonDb);
            return LessonMap;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<LessonOutput> Update(int id, LessonInput update)
        {
            Lesson buscarDb = await _repository.FindById(id);
            if (buscarDb == null)
            {
                throw new Exception("Médico não localizado");
            }
            Lesson LessonUpdate = _mapper.Map<Lesson>(update);
            LessonUpdate.Id = id;
            Lesson LessonDb = await _repository.Update(LessonUpdate);
            LessonOutput LessonMap = _mapper.Map<LessonOutput>(LessonDb);
            return LessonMap;
        }
    }
}
