using PT.Domain.Abstraction;

namespace PT.Domain.Entities.Budget
{
    public static class BudgetErrors
    {
        public static Error InvalidAmount = new("Budget.Invalid", "Enter a valid ");
        public static Error InAccesible = new("Budget.Inaccesible", "You cannot acces this budget ");
        public static Error NotFound = new("Budget.NotFound", "You do not have any budget ");
        public static Error FailedToCreate = new("Budget.FailedToCreate", "Failed To create budget");
    }
}
