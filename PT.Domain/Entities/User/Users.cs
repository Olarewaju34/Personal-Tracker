using PT.Domain.Abstraction;
using PT.Domain.Entities.Transaction;

namespace PT.Domain.Entities.User
{
    public class Users : BaseEntity
    {
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string Phone { get; private set; }

        public string Email { get; private set; }
        public string PassWord { get; private set; }

        public IList<Transactions> Transactions { get; set; }
        public IList<Budget> Budgets { get; set; }
    }
}
