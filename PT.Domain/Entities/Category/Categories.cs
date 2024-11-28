using PT.Domain.Abstraction;
using PT.Domain.Entities.Budget;
using PT.Domain.Entities.Category.Dto;
using PT.Domain.Entities.Transaction;
using PT.Domain.Entities.User;
using PT.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Domain.Entities.Category
{
    public class Categories : BaseEntity
    {
        public string? UserId { get; private set; }
        public Users Users { get; private set; }
        public string? Name { get; private set; }
        public MoneyFlow MoneyFlow { get; private set; }
        public IList<Transactions> Transactions { get; set; }


        public static Categories CreateCategory(string UserId, string Name, MoneyFlow MoneyFlow)
        {
            var category = new Categories
            {
                UserId = UserId,

                Name = Name,
                MoneyFlow = MoneyFlow

            };
            return category;
        }
    }


}
