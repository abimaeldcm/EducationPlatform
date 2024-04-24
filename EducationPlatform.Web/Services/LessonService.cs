using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
using EducationPlatform.Web.Helper;
using EducationPlatform.Web.Domain.Entity;
using EducationPlatform.Web.Services.Interfaces;

namespace EducationPlatform.Web.Services
{
    public class LessonService : ICRUD<LessonOutput, LessonInput>
    {
        private readonly IHttpClientFactory _ClientFactory;
        private const string apiEndpoint = "api/Lesson";
        private readonly JsonSerializerOptions _options;
        private LessonOutput Lesson;
        private IEnumerable<LessonOutput> Lessons;
        private readonly ISessao _isessao;


        public LessonService(IHttpClientFactory clientFactory, ISessao isessao)
        {
            _ClientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _isessao = isessao;
        }

        public async Task<LessonOutput> BuscarPorId(int id)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoLesson = _isessao.BuscarSessaoDoUsuario();

            if (sessaoLesson != null && !string.IsNullOrEmpty(sessaoLesson.Token))
            {
                var tokenJwt = sessaoLesson.Token;

                var requestUri = $"https://localhost:7018/api/Lesson/{id}";

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
                        Lesson = JsonSerializer.Deserialize<LessonOutput>(apiResponse, _options);
                    }
                }
            }

            return Lesson;
        }

        public async Task<IEnumerable<LessonOutput>> BuscarTodos()
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoLesson = _isessao.BuscarSessaoDoUsuario();

            IEnumerable<LessonOutput> Lessons = null;

            if (sessaoLesson != null && !string.IsNullOrEmpty(sessaoLesson.Token))
            {
                var tokenJwt = sessaoLesson.Token;

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://localhost:7018/api/Lesson"),
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        Lessons = JsonSerializer.Deserialize<IEnumerable<LessonOutput>>(apiResponse, _options);
                    }
                }
            }

            return Lessons;
        }

        public async Task<IEnumerable<LessonOutput>> BuscarPorTexto(string termoPesquisa)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoLesson = _isessao.BuscarSessaoDoUsuario();

            IEnumerable<LessonOutput> Lessons = null;

            if (sessaoLesson != null && !string.IsNullOrEmpty(sessaoLesson.Token))
            {
                var tokenJwt = sessaoLesson.Token;

                var requestUri = $"https://localhost:7018/api/Lesson/BuscarPorTexto/{termoPesquisa}";

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
                        Lessons = JsonSerializer.Deserialize<IEnumerable<LessonOutput>>(apiResponse, _options);
                    }
                }
            }

            return Lessons;
        }

        public async Task<LessonOutput> Cadastrar(LessonInput cadastrar)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoLesson = _isessao.BuscarSessaoDoUsuario();

            if (sessaoLesson != null && !string.IsNullOrEmpty(sessaoLesson.Token))
            {
                var tokenJwt = sessaoLesson.Token;

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://localhost:7018/api/Lesson"),
                    Content = new StringContent(JsonSerializer.Serialize(cadastrar), Encoding.UTF8, "application/json")
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        Lesson = JsonSerializer.Deserialize<LessonOutput>(apiResponse, _options);
                    }
                }
            }

            return Lesson;
        }

        public async Task<bool> Delete(int id)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoLesson = _isessao.BuscarSessaoDoUsuario();

            if (sessaoLesson != null && !string.IsNullOrEmpty(sessaoLesson.Token))
            {
                var tokenJwt = sessaoLesson.Token;

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri($"https://localhost:7018/api/Lesson/{id}"),
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.SendAsync(request))
                {
                    return response.IsSuccessStatusCode;
                }
            }

            return false;
        }

        public async Task<object> Editar(int id, LessonInput editar)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoLesson = _isessao.BuscarSessaoDoUsuario();

            if (sessaoLesson != null && !string.IsNullOrEmpty(sessaoLesson.Token))
            {
                var tokenJwt = sessaoLesson.Token;

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri($"https://localhost:7018/api/Lesson/{id}"),
                    Content = new StringContent(JsonSerializer.Serialize(editar), Encoding.UTF8, "application/json")
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        Lesson = JsonSerializer.Deserialize<LessonOutput>(apiResponse, _options);
                    }
                    else
                    {
                        throw new Exception(await response.Content.ReadAsStringAsync());
                    }
                }
            }

            return Lesson;
        }

    }
}
