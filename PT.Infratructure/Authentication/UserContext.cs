using Microsoft.AspNetCore.Http;
using PT.Application.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp;

namespace PT.Infratructure.Authentication
{
    internal sealed class UserContext(IHttpContextAccessor _httpContextAccessorr) : IUserContext
    {
        public string UserId => _httpContextAccessorr.HttpContext.User.GetUserId() ?? throw new ApplicationException("user context is unavailable");
    }
}
