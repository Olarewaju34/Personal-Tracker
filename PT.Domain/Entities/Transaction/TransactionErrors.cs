using PT.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Domain.Entities.Transaction
{
    public class TransactionErrors
    {
        public static Error NotPositiveAmount = new("Transactions.NotPositive", "Enter a Valid Amount"); public static Error NotFound = new("Transactions.NotFound", "No transaction done bu the current user");
        public static Error NullValue = new("Transactions.NullValue", "Enter a Valid Amount");
        public static Error Inaccessibility = new("Transaction.InAccesiblity", "You cannot access this transaction");
        public static Error NoFutureDate = new("Transactions.Present/PastDate", "You cannot type in future date");

    }
}
