using PT.Domain.Abstraction;
using PT.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT.Application.Abstraction.Repositories
{
    public interface IUserRepository : IRepository<Users>
    {
        Task<Users> GetUsersAsync(Expression<Func<Users, bool>> expression);
        Task<Users> GetUsersAsync(string id);

    }
}
