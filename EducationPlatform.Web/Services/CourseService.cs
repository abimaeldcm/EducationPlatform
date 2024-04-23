using System.Text.Json;
using System.Text;
using System.Net.Http.Headers;
using EducationPlatform.Web.Helper;
using EducationPlatform.Web.Domain.Entity;
using EducationPlatform.Web.Services.Interfaces;

namespace EducationPlatform.Web.Services
{
    public class CourseService : ICRUD<CourseOutput, CourseInput>
    {
        private readonly IHttpClientFactory _ClientFactory;
        private const string apiEndpoint = "api/Course";
        private readonly JsonSerializerOptions _options;
        private CourseOutput course;
        private IEnumerable<CourseOutput> courses;
        private readonly ISessao _isessao;


        public CourseService(IHttpClientFactory clientFactory, ISessao isessao)
        {
            _ClientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _isessao = isessao;
        }

        public async Task<CourseOutput> BuscarPorId(int id)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoCourse = _isessao.BuscarSessaoDoUsuario();

            if (sessaoCourse != null && !string.IsNullOrEmpty(sessaoCourse.Token))
            {
                var tokenJwt = sessaoCourse.Token;

                var requestUri = $"https://localhost:7018/api/Course/{id}";

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
                        course = JsonSerializer.Deserialize<CourseOutput>(apiResponse, _options);
                    }
                }
            }

            return course;
        }

        public async Task<IEnumerable<CourseOutput>> BuscarTodos()
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoCourse = _isessao.BuscarSessaoDoUsuario();

            IEnumerable<CourseOutput> Courses = null;

            if (sessaoCourse != null && !string.IsNullOrEmpty(sessaoCourse.Token))
            {
                var tokenJwt = sessaoCourse.Token;

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://localhost:7018/api/Course"),
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        courses = JsonSerializer.Deserialize<IEnumerable<CourseOutput>>(apiResponse, _options);
                    }
                }
            }

            return courses;
        }

        public async Task<IEnumerable<CourseOutput>> BuscarPorTexto(string termoPesquisa)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoCourse = _isessao.BuscarSessaoDoUsuario();

            IEnumerable<CourseOutput> Courses = null;

            if (sessaoCourse != null && !string.IsNullOrEmpty(sessaoCourse.Token))
            {
                var tokenJwt = sessaoCourse.Token;

                var requestUri = $"https://localhost:7018/api/Course/BuscarPorTexto/{termoPesquisa}";

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
                        courses = JsonSerializer.Deserialize<IEnumerable<CourseOutput>>(apiResponse, _options);
                    }
                }
            }

            return courses;
        }

        public async Task<CourseOutput> Cadastrar(CourseInput cadastrar)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoCourse = _isessao.BuscarSessaoDoUsuario();

            if (sessaoCourse != null && !string.IsNullOrEmpty(sessaoCourse.Token))
            {
                var tokenJwt = sessaoCourse.Token;

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri("https://localhost:7018/api/Course"),
                    Content = new StringContent(JsonSerializer.Serialize(cadastrar), Encoding.UTF8, "application/json")
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        course = JsonSerializer.Deserialize<CourseOutput>(apiResponse, _options);
                    }
                }
            }

            return course;
        }

        public async Task<bool> Delete(int id)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoCourse = _isessao.BuscarSessaoDoUsuario();

            if (sessaoCourse != null && !string.IsNullOrEmpty(sessaoCourse.Token))
            {
                var tokenJwt = sessaoCourse.Token;

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri($"https://localhost:7018/api/Course/{id}"),
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.SendAsync(request))
                {
                    return response.IsSuccessStatusCode;
                }
            }

            return false;
        }

        public async Task<object> Editar(int id, CourseInput editar)
        {
            var client = _ClientFactory.CreateClient("EducationPlatform");

            var sessaoCourse = _isessao.BuscarSessaoDoUsuario();

            if (sessaoCourse != null && !string.IsNullOrEmpty(sessaoCourse.Token))
            {
                var tokenJwt = sessaoCourse.Token;

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri($"https://localhost:7018/api/Course/{id}"),
                    Content = new StringContent(JsonSerializer.Serialize(editar), Encoding.UTF8, "application/json")
                };

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

                using (var response = await client.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        course = JsonSerializer.Deserialize<CourseOutput>(apiResponse, _options);
                    }
                    else
                    {
                        throw new Exception(await response.Content.ReadAsStringAsync());
                    }
                }
            }

            return course;
        }

    }
}
