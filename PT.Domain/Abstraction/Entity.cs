using PT.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Domain.Abstraction
{
    public abstract class  BaseEntity : ISoftDelete,IAuditBase

    {
  
        private List<IDomainEvent> _domainEvents = [];
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public string? CreatedFrom { get; set; }
        public string? ModifiedFrom { get; set; }

        public IReadOnlyList<IDomainEvent> GetAllDomainEvents()
        {
            return _domainEvents;
        }

        public void RaiseDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearAllDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
