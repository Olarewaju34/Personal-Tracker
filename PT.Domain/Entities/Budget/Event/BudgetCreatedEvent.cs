using PT.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Domain.Entities.Budget.Event
{
    public record class BudgetCreatedEvent(string BudgetId) :IDomainEvent
    {
    }
}
