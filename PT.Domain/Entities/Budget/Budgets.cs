using PT.Domain.Abstraction;
using PT.Domain.Entities.Category;
using PT.Domain.Entities.User;

namespace PT.Domain.Entities.Budget
{
    public  class Budgets : BaseEntity
    {
        public string? UserId { get;private set; }
        public Users Users { get; private set; }
        public decimal Amount { get; private set; }
        public string CategoryId { get ; private set; }
        public Categories? Categories { get; private set; }
        public string ?Description { get;protected set; }
        public DateRange? Duration { get; private set; }


        public static Budgets CreateBudget(string UserId, string CategoryId, decimal Amount, string Description,DateRange duration,DateTime createdAt)
        {
            Budgets? budget = new Budgets
            {
                UserId = UserId,
                CategoryId = CategoryId,
                Amount = Amount,
                Description = Description,
                Duration = duration,
                Created = createdAt  
            };
            return budget;
        }

    }
}
