using PT.Application.Abstraction.Repositories;
using PT.Domain.Entities.Transaction;
using PT.Infratructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Infratructure.Repositories
{
    public sealed class TransactionsRepository : Repository<Transactions>,ITransactionRepository
    {
        public TransactionsRepository(PTContext context) : base(context)
        {
        }
        
    }
}
