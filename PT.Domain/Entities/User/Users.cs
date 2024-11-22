using PT.Domain.Abstraction;
using PT.Domain.Entities.Budget;
using PT.Domain.Entities.Transaction;
using PT.Domain.Entities.User.Dto;

namespace PT.Domain.Entities.User
{
    public class Users : BaseEntity
    {
        public Users() { }
     
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string Phone { get; private set; }

        public string Email { get; private set; }
        public string PassWord { get; private set; }

        public IList<Transactions> Transactions { get; set; }
        public IList<Budgets> Budgets { get; set; }

        public static Users CreateUser(string firstName,string lastName,string phone,string email,string? password= null)
        {
            var user = new Users()
            {
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                Email = email,
                PassWord = password
            };
            return user;
        }
    }
}
