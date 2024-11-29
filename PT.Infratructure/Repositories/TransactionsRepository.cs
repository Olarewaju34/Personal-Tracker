using Microsoft.EntityFrameworkCore;
using PT.Application.Abstraction.Repositories;
using PT.Domain.Entities.Transaction;
using PT.Infratructure.Data;

namespace PT.Infratructure.Repositories
{
    public sealed class TransactionsRepository : Repository<Transactions>, ITransactionRepository
    {
        public TransactionsRepository(PTContext _context) : base(_context)
        {
        }

        public async Task<Transactions> GetTransactions(string id, CancellationToken cancellationToken = default)
        {
            var transaction = await  _context.Transactions.Include(tr=>tr.Category).FirstOrDefaultAsync(tr=>tr.Id== id);
            return transaction;
        }

 
    }
}
