using System.Net.Http.Headers;

namespace EducationPlatform.Web.Helper
{
    public static class TokenRequest
    {
        public static HttpClient InsertToken(IHttpClientFactory clientFactory, ISessao sessao)
        {
            var client = clientFactory.CreateClient("EducationPlatformAPI");
            // Obter a sessão do usuário
            var sessaoUser = sessao.BuscarSessaoDoUsuario();

            // Verificar se a sessão e o token são válidos
            if (sessaoUser != null && !string.IsNullOrEmpty(sessaoUser.Token))
            {
                // Obter o token JWT da sua aplicação
                var tokenJwt = sessaoUser.Token;

                // Adicionar o token JWT ao cabeçalho Authorization
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJwt);

            }
            return client;
        }
    }
}
