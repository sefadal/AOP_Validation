using Core.Entites.Concrete;
using System.Collections.Generic;

namespace Core.Utilities.Securty.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
