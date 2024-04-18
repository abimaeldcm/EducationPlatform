using AutoMapper;
using EducationPlatform.Application.Interface;
using EducationPlatform.Domain.Entity;
using EducationPlatform.Infra.Data.Interfaces;

namespace EducationPlatform.Application.Service
{
    public class SignatureService : ICRUDService<SignatureOutput, SignatureInput>
    {
        private readonly ICRUDRepository<Signature> _repository;
        private readonly IMapper _mapper;

        public SignatureService(ICRUDRepository<Signature> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SignatureOutput> FindById(int id)
        {
            Signature SignatureDb = await _repository.FindById(id);
            SignatureOutput SignatureMap = _mapper.Map<SignatureOutput>(SignatureDb);
            return SignatureMap;
        }

        public async Task<List<SignatureOutput>> GetAll()
        {
            List<Signature> SignatureDb = await _repository.GetAll();
            List<SignatureOutput> SignatureMap = _mapper.Map<List<SignatureOutput>>(SignatureDb);
            return SignatureMap;
        }

        public async Task<SignatureOutput> Create(SignatureInput create)
        {
            Signature SignatureCadastro = _mapper.Map<Signature>(create);
            Signature SignatureDb = await _repository.Create(SignatureCadastro);
            SignatureOutput SignatureMap = _mapper.Map<SignatureOutput>(SignatureDb);
            return SignatureMap;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<SignatureOutput> Update(int id, SignatureInput update)
        {
            Signature buscarDb = await _repository.FindById(id);
            if (buscarDb == null)
            {
                throw new Exception("Signature não localizado");
            }
            Signature SignatureUpdate = _mapper.Map<Signature>(update);
            SignatureUpdate.Id = id;
            Signature SignatureDb = await _repository.Update(SignatureUpdate);
            SignatureOutput SignatureMap = _mapper.Map<SignatureOutput>(SignatureDb);
            return SignatureMap;
        }

    }
}
