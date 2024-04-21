using AutoMapper;
using EducationPlatform.Application.Interface;
using EducationPlatform.Domain.Entity;
using EducationPlatform.Domain.Entity.EntityRelational;
using EducationPlatform.Infra.Data.Interfaces;

namespace EducationPlatform.Application.Services
{
    public class UserService : ICRUDService<UserOutput, UserInput>, ILoginService
    {

        private readonly ICRUDRepository<UserEntity> _repository;
        private readonly ICRUDRepository<UserSignature> _signatureRepository;
        private readonly IUserSignatureRepository _userSignatureRepository;
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;

        public UserService(ICRUDRepository<UserEntity> repository, ICRUDRepository<UserSignature> signatureRepository, IUserSignatureRepository userSignatureRepository, ILoginRepository loginRepository, IMapper mapper)
        {
            _repository = repository;
            _signatureRepository = signatureRepository;
            _userSignatureRepository = userSignatureRepository;
            _loginRepository = loginRepository;
            _mapper = mapper;
        }

        public async Task<UserOutput> FindLogin(string CPF, string password)
        {
           // password = BCrypt.Net.BCrypt.HashPassword(password);
            var UserDb = await _loginRepository.FindLogin(CPF, password);
            UserOutput UserMap = _mapper.Map<UserOutput>(UserDb);
            if (UserDb is not null)
            {
                var userSiganture = await _userSignatureRepository.FindByUser(UserDb.Id);
                if (userSiganture is null)
                {
                    return UserMap;
                }
                UserMap.UserSignature = userSiganture;
                UserMap.UserSignature.SignatureId = userSiganture.SignatureId;

            }

            return UserMap;
        }

        public async Task<UserOutput> FindById(int id)
        {
            UserEntity UserDb = await _repository.FindById(id);
            UserOutput UserMap = _mapper.Map<UserOutput>(UserDb);
            return UserMap;
        }

        public async Task<List<UserOutput>> GetAll()
        {
            List<UserEntity> UserDb = await _repository.GetAll();
            List<UserOutput> UserMap = _mapper.Map<List<UserOutput>>(UserDb);
            return UserMap;
        }

        public async Task<UserOutput> Create(UserInput create)
        {
            UserEntity UserCadastro = _mapper.Map<UserEntity>(create);
            create.Password = BCrypt.Net.BCrypt.HashPassword(create.Password);

            //Chamar serviço de envio de e-mail de senha para o usuário.

            UserEntity UserDb = await _repository.Create(UserCadastro);
            UserOutput UserMap = _mapper.Map<UserOutput>(UserDb);

            return UserMap;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<UserOutput> Update(int id, UserInput update)
        {
            UserEntity buscarDb = await _repository.FindById(id);

            if (buscarDb == null)
            {
                throw new Exception("User não localizado");
            }

            UserEntity UserUpdate = _mapper.Map<UserEntity>(update);
            UserUpdate.Id = id;

            if (update.Password is not null)
            {
                update.Password = BCrypt.Net.BCrypt.HashPassword(update.Password);
            }

            UserEntity UserDb = await _repository.Update(UserUpdate);
            UserOutput UserMap = _mapper.Map<UserOutput>(UserDb);

            return UserMap;
        }
    }
}
