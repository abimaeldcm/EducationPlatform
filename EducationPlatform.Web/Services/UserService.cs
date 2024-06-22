using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
using EducationPlatform.Web.Helper;
using EducationPlatform.Web.Domain.Entity;
using EducationPlatform.Web.Services.Interfaces;
using System.Net;
using System;

namespace EducationPlatform.Web.Services
{
    public class UserService : ICRUD<UserOutput, UserInput>, ILoginService
    {
        private readonly IHttpClientFactory _ClientFactory;
        private const string apiEndpoint = "api/User/";
        private const string apiEndpointLogin = "api/User/Login";
        private readonly JsonSerializerOptions _options;
        private UserOutput user;
        private UserLogged userLogged;
        private IEnumerable<UserOutput> users;
        private readonly ISessao _isessao;


        public UserService(IHttpClientFactory clientFactory, ISessao isessao)
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
                    userLogged = JsonSerializer.Deserialize<UserLogged>(apiResponse, _options);
                }
                else
                {
                    throw new Exception(await response.Content.ReadAsStringAsync());
                }
            }

            return userLogged;
        }


        public async Task<UserOutput> BuscarPorId(int id)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoUser = _isessao.BuscarSessaoDoUsuario();

            if (sessaoUser != null && !string.IsNullOrEmpty(sessaoUser.Token))
            {
                var tokenJwt = sessaoUser.Token;

                var requestUri = $"https://localhost:7018/api/User/{id}";

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(requestUri),
                };

                request.Headers.Add("Authorization", $"Bearer {tokenJwt}");

                using (var response = await client.SendAsync(request))
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

        public async Task<IEnumerable<UserOutput>> BuscarTodos()
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoUser = _isessao.BuscarSessaoDoUsuario();

            IEnumerable<UserOutput> users = null;

            if (sessaoUser != null && !string.IsNullOrEmpty(sessaoUser.Token))
            {
                var tokenJwt = sessaoUser.Token;

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://localhost:7018/api/User"),
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        users = JsonSerializer.Deserialize<IEnumerable<UserOutput>>(apiResponse, _options);
                    }
                }
            }

            return users;
        }

        public async Task<IEnumerable<UserOutput>> BuscarPorTexto(string termoPesquisa)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoUser = _isessao.BuscarSessaoDoUsuario();

            IEnumerable<UserOutput> users = null;

            if (sessaoUser != null && !string.IsNullOrEmpty(sessaoUser.Token))
            {
                var tokenJwt = sessaoUser.Token;

                var requestUri = $"https://localhost:7018/api/User/BuscarPorTexto/{termoPesquisa}";

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(requestUri),
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        users = JsonSerializer.Deserialize<IEnumerable<UserOutput>>(apiResponse, _options);
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
                    else if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        throw new Exception("Erro");
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

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri($"https://localhost:7018/api/User/{id}"),
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.SendAsync(request))
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

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri($"https://localhost:7018/api/User/{id}"),
                    Content = new StringContent(JsonSerializer.Serialize(editar), Encoding.UTF8, "application/json")
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.SendAsync(request))
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

            return user;
        }

        public Task<UserOutput> Create(UserInput user)
        {
            throw new NotImplementedException();
        }
    }
}

