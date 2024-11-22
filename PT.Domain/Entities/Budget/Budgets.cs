using PT.Domain.Abstraction;
using PT.Domain.Entities.Category;
using PT.Domain.Entities.User;

namespace PT.Domain.Entities.Budget
{
    public  class Budgets : BaseEntity
    {
        public string UserId { get;private set; }
        public Users Users { get; private set; }
        public decimal Amount { get; private set; }
        public string CategoryId { get ; private set; }
        public Categories Categories { get; private set; }
        public string Description { get;protected set; }
        public DateTime DateOnly { get; private set; }

    }
}
