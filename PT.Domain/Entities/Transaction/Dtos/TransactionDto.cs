using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Domain.Entities.Transaction.Dtos
{
    internal class TransactionDto(decimal Amount, string CategoryId, DateOnly DateOnly, string Description);
 
}
