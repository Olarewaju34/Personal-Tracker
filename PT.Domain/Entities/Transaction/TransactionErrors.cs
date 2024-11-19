using PT.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Domain.Entities.Transaction
{
    internal class TransactionErrors
    {
        public static Error NotPositiveAmount = new ("Transactions.NotPositive", "Enter a Valid Amount"); 
        public static Error NullValue = new ("Transactions.NullValue", "Enter a Valid Amount");  
        public static Error NoFutureDate = new ("Transactions.Present/PastDate", "You cannot type in future date");

    }
}
