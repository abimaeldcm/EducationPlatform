using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
using EducationPlatform.Web.Helper;
using EducationPlatform.Web.Domain.Entity;
using EducationPlatform.Web.Services.Interfaces;

namespace Consultorio.Web.Services
{
    public class UserService : ICRUD<UserOutput, UserInput>
    {
        private readonly IHttpClientFactory _ClientFactory;
        private const string apiEndpoint = "api/User/";
        private readonly JsonSerializerOptions _options;
        private UserOutput user;
        private IEnumerable<UserOutput> users;
        private readonly ISessao _isessao;


        public UserService(IHttpClientFactory clientFactory, ISessao isessao)
        {
            _ClientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _isessao = isessao;
        }

        public async Task<UserOutput> BuscarPorId(int id)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoUser = _isessao.BuscarSessaoDoUsuario();

            if (sessaoUser != null && !string.IsNullOrEmpty(sessaoUser.Token))
            {
                var tokenJwt = sessaoUser.Token;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.GetAsync(apiEndpoint + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        user = JsonSerializer.Deserialize<UserOutput>(apiResponse, _options);
                    }
                }
            }

            return user;
        }

        public async Task<IEnumerable<UserOutput>> BuscarPorTexto(string termoPesquisa)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoUser = _isessao.BuscarSessaoDoUsuario();

            if (sessaoUser != null && !string.IsNullOrEmpty(sessaoUser.Token))
            {
                var tokenJwt = sessaoUser.Token;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.GetAsync(apiEndpoint + "BuscarPorTexto/" + termoPesquisa))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        users = JsonSerializer.Deserialize<List<UserOutput>>(apiResponse, _options);
                    }
                }
            }

            return users;
        }

        public async Task<IEnumerable<UserOutput>> BuscarTodos()
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoUser = _isessao.BuscarSessaoDoUsuario();

            if (sessaoUser != null && !string.IsNullOrEmpty(sessaoUser.Token))
            {
                var tokenJwt = sessaoUser.Token;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.GetAsync(apiEndpoint))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStreamAsync();
                        users = (await JsonSerializer.DeserializeAsync<IEnumerable<UserOutput>>(apiResponse, _options));
                    }
                }
            }
            
            return users;
        }

        public async Task<UserOutput> Cadastrar(UserInput cadastrar)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoUser = _isessao.BuscarSessaoDoUsuario();

            if (sessaoUser != null && !string.IsNullOrEmpty(sessaoUser.Token))
            {
                var tokenJwt = sessaoUser.Token;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                var content = new StringContent(JsonSerializer.Serialize(cadastrar), Encoding.UTF8, "application/json");

                using (var response = await client.PostAsync(apiEndpoint, content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        user = JsonSerializer.Deserialize<UserOutput>(apiResponse, _options);
                    }
                }
            }

            return user;
        }

        public async Task<bool> Delete(int id)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoUser = _isessao.BuscarSessaoDoUsuario();

            if (sessaoUser != null && !string.IsNullOrEmpty(sessaoUser.Token))
            {
                var tokenJwt = sessaoUser.Token;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.DeleteAsync(apiEndpoint + id))
                {
                    return response.IsSuccessStatusCode;
                }
            }

            return false;
        }

        public async Task<object> Editar(int id, UserInput editar)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoUser = _isessao.BuscarSessaoDoUsuario();

            if (sessaoUser != null && !string.IsNullOrEmpty(sessaoUser.Token))
            {
                var tokenJwt = sessaoUser.Token;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                var content = new StringContent(JsonSerializer.Serialize(editar), Encoding.UTF8, "application/json");

                using (var response = await client.PutAsync(apiEndpoint + id, content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        user = JsonSerializer.Deserialize<UserOutput>(apiResponse, _options);
                    }
                    else
                    {
                        throw new Exception(await response.Content.ReadAsStringAsync());
                    }
                }
            }
            return null;
        }
    }
}

