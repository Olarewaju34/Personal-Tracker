using PT.Domain.Abstraction;
using PT.Domain.Entities.Budget;
using PT.Domain.Entities.Transaction;
using PT.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Domain.Entities.Category
{
    public class Categories :BaseEntity
    {
        public string Name {  get;private  set; }
        public MoneyFlow MoneyFlow { get; private set; }
        public IList<Transactions> Transactions { get;  set; }
    }
}
