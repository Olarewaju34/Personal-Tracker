using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using PT.Application.Abstraction.Repositories;
using PT.Domain.Abstraction;
using PT.Domain.Entities.User;
using PT.Infratructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PT.Infratructure.Repositories;

    public class UserRepository(PTContext _context) : Repository<Users>(_context), IUserRepository
    {
        public async Task<Users?> GetUsersAsync(Expression<Func<Users, bool>> expression)
        {
            var user = await _context.Users.Include(u=>u.Transactions).ThenInclude(tr=>tr.Category).FirstOrDefaultAsync(expression);
            return user;
        }

        public async Task<Users?> GetUsersAsync(string id)
        {
            var user = await _context.Users.Include(u => u.Transactions).ThenInclude(tr => tr.Category).FirstOrDefaultAsync(u=>u.Id == id);
            return user;    
    }
}
