using PT.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Domain.Entities.Category.Dto
{
    public record  CreateCategoryDto(string UserId,string Name,MoneyFlow MoneyFlow);

}
