using Ncode.Grocerly.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ncode.Grocerly.RestApi.Authentication
{
    public static class ExtensionMethods
    {
        public static string GetUsername(this ClaimsPrincipal claimsPrincipal)
        {
            var usernameClaim = claimsPrincipal.Claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Name));
            if (usernameClaim is null)
            {
                throw new UnregisteredShopperException();
            }

            return usernameClaim.Value;
        }
    }
}
