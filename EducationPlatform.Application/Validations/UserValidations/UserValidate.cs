using EducationPlatform.Domain.Entity.Enum;
using System.Security.Claims;

namespace EducationPlatform.Application.Validations.UserValidations
{
    public static class UserValidate
    {
        public static bool ValidateFindUser(int id, ClaimsPrincipal user)
        {
            try
            {           
                var userIdClaim = user.FindFirst("id");

                if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int idClaim) && idClaim == id)
                {
                    return true;
                }  

                var userSignatureClaim = user.FindFirst("UserSignature");
                var userClaimRole = user.FindFirst(c => c.Type == ClaimTypes.Role).Value;

                if (userClaimRole is not null && userClaimRole == EAccessLevel.Manager.ToString())
                {
                    return true;
                }

            }
            catch (Exception)
            {

                throw;
            }

            return false;
        }
    }
}
