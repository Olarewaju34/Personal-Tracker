using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Domain.Shared
{
    public interface IAuditBase
    {
        public bool IsActive { get; set; }

        public string? CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Modified { get; set; }

        public string? CreatedFrom { get; set; }

        public string? ModifiedFrom { get; set; }
    }
}
