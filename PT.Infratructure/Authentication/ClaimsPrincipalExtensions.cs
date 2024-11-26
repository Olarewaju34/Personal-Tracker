using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PT.Infratructure.Authentication
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal? principal)
        {
            string? UserId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            return UserId?? throw new ApplicationException("UserId does not exist");
        }
    }
}
