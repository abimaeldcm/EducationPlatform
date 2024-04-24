using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
using EducationPlatform.Web.Helper;
using EducationPlatform.Web.Domain.Entity;
using EducationPlatform.Web.Services.Interfaces;

namespace EducationPlatform.Web.Services
{
    public class SignatureService : ICRUD<SignatureOutput, SignatureInput>
    {
        private readonly IHttpClientFactory _ClientFactory;
        private const string apiEndpoint = "api/Signature";
        private readonly JsonSerializerOptions _options;
        private SignatureOutput Signature;
        private IEnumerable<SignatureOutput> Signatures;
        private readonly ISessao _isessao;


        public SignatureService(IHttpClientFactory clientFactory, ISessao isessao)
        {
            _ClientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _isessao = isessao;
        }

        public async Task<SignatureOutput> BuscarPorId(int id)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoSignature = _isessao.BuscarSessaoDoUsuario();

            if (sessaoSignature != null && !string.IsNullOrEmpty(sessaoSignature.Token))
            {
                var tokenJwt = sessaoSignature.Token;

                var requestUri = $"https://localhost:7018/api/Signature/{id}";

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
                        Signature = JsonSerializer.Deserialize<SignatureOutput>(apiResponse, _options);
                    }
                }
            }

            return Signature;
        }

        public async Task<IEnumerable<SignatureOutput>> BuscarTodos()
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoSignature = _isessao.BuscarSessaoDoUsuario();

            IEnumerable<SignatureOutput> Signatures = null;

            if (sessaoSignature != null && !string.IsNullOrEmpty(sessaoSignature.Token))
            {
                var tokenJwt = sessaoSignature.Token;

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://localhost:7018/api/Signature"),
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        Signatures = JsonSerializer.Deserialize<IEnumerable<SignatureOutput>>(apiResponse, _options);
                    }
                }
            }

            return Signatures;
        }

        public async Task<IEnumerable<SignatureOutput>> BuscarPorTexto(string termoPesquisa)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoSignature = _isessao.BuscarSessaoDoUsuario();

            IEnumerable<SignatureOutput> Signatures = null;

            if (sessaoSignature != null && !string.IsNullOrEmpty(sessaoSignature.Token))
            {
                var tokenJwt = sessaoSignature.Token;

                var requestUri = $"https://localhost:7018/api/Signature/BuscarPorTexto/{termoPesquisa}";

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
                        Signatures = JsonSerializer.Deserialize<IEnumerable<SignatureOutput>>(apiResponse, _options);
                    }
                }
            }

            return Signatures;
        }

        public async Task<SignatureOutput> Cadastrar(SignatureInput cadastrar)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoSignature = _isessao.BuscarSessaoDoUsuario();

            if (sessaoSignature != null && !string.IsNullOrEmpty(sessaoSignature.Token))
            {
                var tokenJwt = sessaoSignature.Token;

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://localhost:7018/api/Signature"),
                    Content = new StringContent(JsonSerializer.Serialize(cadastrar), Encoding.UTF8, "application/json")
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        Signature = JsonSerializer.Deserialize<SignatureOutput>(apiResponse, _options);
                    }
                }
            }

            return Signature;
        }

        public async Task<bool> Delete(int id)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoSignature = _isessao.BuscarSessaoDoUsuario();

            if (sessaoSignature != null && !string.IsNullOrEmpty(sessaoSignature.Token))
            {
                var tokenJwt = sessaoSignature.Token;

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri($"https://localhost:7018/api/Signature/{id}"),
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.SendAsync(request))
                {
                    return response.IsSuccessStatusCode;
                }
            }

            return false;
        }

        public async Task<object> Editar(int id, SignatureInput editar)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoSignature = _isessao.BuscarSessaoDoUsuario();

            if (sessaoSignature != null && !string.IsNullOrEmpty(sessaoSignature.Token))
            {
                var tokenJwt = sessaoSignature.Token;

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri($"https://localhost:7018/api/Signature/{id}"),
                    Content = new StringContent(JsonSerializer.Serialize(editar), Encoding.UTF8, "application/json")
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        Signature = JsonSerializer.Deserialize<SignatureOutput>(apiResponse, _options);
                    }
                    else
                    {
                        throw new Exception(await response.Content.ReadAsStringAsync());
                    }
                }
            }

            return Signature;
        }

    }
}
