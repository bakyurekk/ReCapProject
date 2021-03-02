using Core.Entities.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Ultilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
