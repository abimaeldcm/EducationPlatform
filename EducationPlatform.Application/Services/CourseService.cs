using AutoMapper;
using EducationPlatform.Application.Interface;
using EducationPlatform.Domain.Entity;
using EducationPlatform.Infra.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace EducationPlatform.Application.Service
{
    public class CourseService : ICRUDService<CourseOutput, CourseInput>
    {
        private readonly ICRUDRepository<Course> _repository;
        private readonly IMapper _mapper;

        public CourseService(ICRUDRepository<Course> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CourseOutput> FindById(int id)
        {
            Course CourseDb = await _repository.FindById(id);
            CourseOutput CourseMap = _mapper.Map<CourseOutput>(CourseDb);
            return CourseMap;
        }

        public async Task<List<CourseOutput>> GetAll()
        {
            List<Course> CourseDb = await _repository.GetAll();
            List<CourseOutput> CourseMap = _mapper.Map<List<CourseOutput>>(CourseDb);
            return CourseMap;
        }

        public async Task<CourseOutput> Create(CourseInput create)
        {
            Course CourseCadastro = _mapper.Map<Course>(create);
            Course CourseDb = await _repository.Create(CourseCadastro);
            CourseOutput CourseMap = _mapper.Map<CourseOutput>(CourseDb);
            return CourseMap;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<CourseOutput> Update(int id, CourseInput update)
        {
            Course buscarDb = await _repository.FindById(id);
            if (buscarDb == null)
            {
                throw new Exception("Médico não localizado");
            }
            Course CourseUpdate = _mapper.Map<Course>(update);
            CourseUpdate.Id = id;
            Course CourseDb = await _repository.Update(CourseUpdate);
            CourseOutput CourseMap = _mapper.Map<CourseOutput>(CourseDb);
            return CourseMap;
        }
    }
}
