using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Domain.Entities.Transaction.Dtos
{
    public record  UpdateTransactionDto(string Description, decimal Amount)
    {
    }
}
