using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Domain.Entities.Transaction.Dtos
{
    public record class CreateTransactionDto(string UserId, decimal Amount, string CategoryId,DateOnly DateOnly,string Description);
 
}
