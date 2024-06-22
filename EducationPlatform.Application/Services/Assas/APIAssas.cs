using EducationPlatform.Domain.Entity;
using EducationPlatform.Domain.Entity.AssasEntity;
using EducationPlatform.Domain.Entity.Users;
using System.Net.Http.Headers;
using System.Reflection.PortableExecutable;
using System.Text.Json;


namespace EducationPlatform.Application.Services.Assas
{
    public class APIAssas : IAPIAssas
    {
        public async Task<UserAssas> Create(UserEntity user)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://sandbox.asaas.com/api/v3/customers"),
                Headers =
                {
                    { "accept", "application/json" },
                    { "access_token", "$aact_YTU5YTE0M2M2N2I4MTliNzk0YTI5N2U5MzdjNWZmNDQ6OjAwMDAwMDAwMDAwMDAwODMzOTA6OiRhYWNoXzA1ZjE2NmNiLWZkYzgtNDNmYS1iY2Y2LTg4YTJlZDRhMTk2Zg==" },
                },
                Content = new StringContent($"{{\"name\":\"{user.FullName}\",\"cpfCnpj\":\"{user.CPF}\",\"email\":\"{user.Email}\",\"mobilePhone\":\"{user.PhoneNumber}\"}}")
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    }
                }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var userRegistred = JsonSerializer.Deserialize<UserAssas>(body);

                return userRegistred;
            }
        }
    }
}
