using PT.Application.Abstraction.Repositories;
using PT.Domain.Entities.Category;
using PT.Domain.Entities.Transaction;
using PT.Infratructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Infratructure.Repositories
{
    public sealed class CategoryRepository : Repository<Categories>, ICategoryRepository
    {
        public CategoryRepository(PTContext context) : base(context)
        {
        }

    }
}
