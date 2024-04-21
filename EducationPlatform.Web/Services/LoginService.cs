using Consultorio.Web.Services.Interfaces;
using EducationPlatform.Web.Domain.Entity;
using EducationPlatform.Web.Helper;
using EducationPlatform.Web.Services.Interfaces;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace EducationPlatform.Web.Services
{
    public class LoginService : ICRUD<UserOutput, UserInput>, ILoginService
    {
        private readonly IHttpClientFactory _ClientFactory;
        private const string apiEndpoint = "api/Login/";
        private const string apiEndpointLogin = "api/User/Login";
        private readonly JsonSerializerOptions _options;
        private dynamic Login;
        private UserOutput LoginAction;
        private IEnumerable<UserOutput> LoginActions;
        private readonly ISessao _isessao;


        public LoginService(IHttpClientFactory clientFactory, ISessao isessao)
        {
            _ClientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _isessao = isessao;
        }
        public async Task<UserLogged> FindLogin(Login user)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");

            using (var response = await client.PostAsync(apiEndpointLogin, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    Login = JsonSerializer.Deserialize<UserLogged>(apiResponse, _options);
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }

            return Login;
        }
        public async Task<UserOutput> BuscarPorId(int id)
        {
            var client = TokenRequest.InsertToken(_ClientFactory, _isessao);

            using (var response = await client.GetAsync(apiEndpoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    LoginAction = JsonSerializer.Deserialize<UserOutput>(apiResponse, _options);
                }
            }

            return LoginAction;
        }

        public async Task<IEnumerable<UserOutput>> BuscarPorTexto(string termoPesquisa)
        {
            var client = TokenRequest.InsertToken(_ClientFactory, _isessao);

            using (var response = await client.GetAsync(apiEndpoint + "BuscarPorTexto/" + termoPesquisa))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    LoginActions = JsonSerializer.Deserialize<List<UserOutput>>(apiResponse, _options);
                }
            }

            return LoginActions;
        }
    public async Task<IEnumerable<UserOutput>> BuscarTodos()
    {
        var client = TokenRequest.InsertToken(_ClientFactory, _isessao);

        using (var response = await client.GetAsync(apiEndpoint))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStreamAsync();
                LoginActions = (await JsonSerializer
                            .DeserializeAsync<List<UserOutput>>(apiResponse, _options));
            }
            else
            {
                //Modificar depois
            }
        }

        return LoginActions;
    }
    public async Task<UserOutput> Cadastrar(UserInput cadastrar)
    {
        var client = TokenRequest.InsertToken(_ClientFactory, _isessao);

        var content = new StringContent(JsonSerializer.Serialize(cadastrar), Encoding.UTF8, "application/json");

        using (var response = await client.PostAsync(apiEndpoint, content))
        {
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = await response.Content.ReadAsStringAsync();
                LoginAction = JsonSerializer.Deserialize<UserOutput>(apiResponse, _options);
            }
        }

        return LoginAction;
    }

    public async Task<bool> Delete(int id)
    {
        var client = TokenRequest.InsertToken(_ClientFactory, _isessao);

        using (var response = await client.DeleteAsync(apiEndpoint + id))
        {
            return response.IsSuccessStatusCode;
        }

        return false;
    }

    public async Task<object> Editar(int id, UserInput editar)
    {
        var client = _ClientFactory.CreateClient("EducationPlatformAPI");

        // Obter a sessão do usuário
        var sessaoUser = _isessao.BuscarSessaoDoUsuario();

        // Verificar se a sessão e o token são válidos
        if (sessaoUser != null && !string.IsNullOrEmpty(sessaoUser.Token))
        {
            // Obter o token JWT da sua aplicação
            var tokenJwt = sessaoUser.Token;

            // Adicionar o token JWT ao cabeçalho Authorization
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);


            var content = new StringContent(JsonSerializer.Serialize(editar), Encoding.UTF8, "application/json");

            using (var response = await client.PutAsync(apiEndpoint + id, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    LoginAction = JsonSerializer.Deserialize<UserOutput>(apiResponse, _options);
                }
            }
        }

        return LoginAction;
    }
}
}

