using PT.Application.Abstraction.Messaging;
using PT.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Application.Features.Command.Transactions
{
    internal class CreateTransactionsCommandHandler : ICommandHandler<CreateTransactionsCommand, Result>
    {
        public async Task<Result<Result>> Handle(CreateTransactionsCommand request, CancellationToken cancellationToken)
        {
            var transactions =
        }
    }
}
