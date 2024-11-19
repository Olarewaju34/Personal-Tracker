using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Domain.Entities.Transaction.Events
{
    public record TransactionCreatedEventI(string TransactionId)
    {
    }
}
