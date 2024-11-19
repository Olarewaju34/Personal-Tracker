using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Domain.Abstraction
{
    public  interface IEntity
    {
        IReadOnlyList<IDomainEvent> GetDomainEvents();
    }
}
