using PT.Application.Abstraction.Repositories;
using PT.Domain.Abstraction;
using PT.Domain.Entities.User;
using PT.Infratructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Infratructure.Repositories
{
    public class UserRepository(PTContext _context) : Repository<Users>(_context),IUserRepository
    {
       
    }
}
