using PT.Application.Abstraction.Messaging;
using PT.Domain.Abstraction;
using PT.Domain.Entities.Category.Dto;
using PT.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PT.Application.Features.Command.Category.CreateCategory
{
    public record CreateCategoryCommand(string UserId, string Name, MoneyFlow MoneyFlow) : ICommand<Result>
    {
    }
}
