using PT.Domain.Abstraction;
using PT.Domain.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Application.Abstraction.Repositories
{
    internal interface ITransactionRepository :IRepository<Transactions>
    {
    }
}
