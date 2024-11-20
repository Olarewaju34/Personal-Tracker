using PT.Domain.Abstraction;
using PT.Domain.Entities.Budget;
using PT.Domain.Entities.Transaction;
using PT.Domain.Entities.User.Dto;

namespace PT.Domain.Entities.User
{
    public class Users : BaseEntity
    {
        public Users(string firstname, string lastname, string Phone, string Email,string password) 
        {
            Firstname = firstname;
            Lastname = lastname;
            Phone1 = Phone;
            Email1 = Email;
            PassWord = password;
        }
        public string? FirstName { get; private set; }
        public string Firstname { get; }
        public string Lastname { get; }
        public string Phone1 { get; }
        public string Email1 { get; }
        public string? LastName { get; private set; }
        public string Phone { get; private set; }

        public string Email { get; private set; }
        public string PassWord { get; private set; }

        public IList<Transactions> Transactions { get; set; }
        public IList<Budgets> Budgets { get; set; }

        public static Users CreateUser(CreateNewUserDto dto)
        {
            var user = new Users(dto.FirstName,dto.LastName,dto.PhoneNumber,dto.UserName,dto.Password);
            return user;
        }
    }
}
