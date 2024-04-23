using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
using EducationPlatform.Web.Helper;
using EducationPlatform.Web.Domain.Entity;
using EducationPlatform.Web.Services.Interfaces;

namespace EducationPlatform.Web.Services
{
    public class BlockService : ICRUD<BlockOutput, BlockInput>
    {
        private readonly IHttpClientFactory _ClientFactory;
        private const string apiEndpoint = "api/Block";
        private readonly JsonSerializerOptions _options;
        private BlockOutput Block;
        private IEnumerable<BlockOutput> Blocks;
        private readonly ISessao _isessao;


        public BlockService(IHttpClientFactory clientFactory, ISessao isessao)
        {
            _ClientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _isessao = isessao;
        }

        public async Task<BlockOutput> BuscarPorId(int id)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoBlock = _isessao.BuscarSessaoDoUsuario();

            if (sessaoBlock != null && !string.IsNullOrEmpty(sessaoBlock.Token))
            {
                var tokenJwt = sessaoBlock.Token;

                var requestUri = $"https://localhost:7018/api/Block/{id}";

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
                        Block = JsonSerializer.Deserialize<BlockOutput>(apiResponse, _options);
                    }
                }
            }

            return Block;
        }

        public async Task<IEnumerable<BlockOutput>> BuscarTodos()
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoBlock = _isessao.BuscarSessaoDoUsuario();

            IEnumerable<BlockOutput> Blocks = null;

            if (sessaoBlock != null && !string.IsNullOrEmpty(sessaoBlock.Token))
            {
                var tokenJwt = sessaoBlock.Token;

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://localhost:7018/api/Block"),
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        Blocks = JsonSerializer.Deserialize<IEnumerable<BlockOutput>>(apiResponse, _options);
                    }
                }
            }

            return Blocks;
        }

        public async Task<IEnumerable<BlockOutput>> BuscarPorTexto(string termoPesquisa)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoBlock = _isessao.BuscarSessaoDoUsuario();

            IEnumerable<BlockOutput> Blocks = null;

            if (sessaoBlock != null && !string.IsNullOrEmpty(sessaoBlock.Token))
            {
                var tokenJwt = sessaoBlock.Token;

                var requestUri = $"https://localhost:7018/api/Block/BuscarPorTexto/{termoPesquisa}";

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
                        Blocks = JsonSerializer.Deserialize<IEnumerable<BlockOutput>>(apiResponse, _options);
                    }
                }
            }

            return Blocks;
        }

        public async Task<BlockOutput> Cadastrar(BlockInput cadastrar)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoBlock = _isessao.BuscarSessaoDoUsuario();

            if (sessaoBlock != null && !string.IsNullOrEmpty(sessaoBlock.Token))
            {
                var tokenJwt = sessaoBlock.Token;

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://localhost:7018/api/Block"),
                    Content = new StringContent(JsonSerializer.Serialize(cadastrar), Encoding.UTF8, "application/json")
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        Block = JsonSerializer.Deserialize<BlockOutput>(apiResponse, _options);
                    }
                }
            }

            return Block;
        }

        public async Task<bool> Delete(int id)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoBlock = _isessao.BuscarSessaoDoUsuario();

            if (sessaoBlock != null && !string.IsNullOrEmpty(sessaoBlock.Token))
            {
                var tokenJwt = sessaoBlock.Token;

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri($"https://localhost:7018/api/Block/{id}"),
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.SendAsync(request))
                {
                    return response.IsSuccessStatusCode;
                }
            }

            return false;
        }

        public async Task<object> Editar(int id, BlockInput editar)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoBlock = _isessao.BuscarSessaoDoUsuario();

            if (sessaoBlock != null && !string.IsNullOrEmpty(sessaoBlock.Token))
            {
                var tokenJwt = sessaoBlock.Token;

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri($"https://localhost:7018/api/Block/{id}"),
                    Content = new StringContent(JsonSerializer.Serialize(editar), Encoding.UTF8, "application/json")
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        Block = JsonSerializer.Deserialize<BlockOutput>(apiResponse, _options);
                    }
                    else
                    {
                        throw new Exception(await response.Content.ReadAsStringAsync());
                    }
                }
            }

            return Block;
        }

    }
}
