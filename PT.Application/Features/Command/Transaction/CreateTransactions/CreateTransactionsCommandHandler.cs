using PT.Application.Abstraction.Messaging;
using PT.Application.Abstraction.Repositories;
using PT.Domain.Abstraction;
using PT.Domain.Entities.Transaction;
using PT.Domain.Entities.User;
namespace PT.Application.Features.Command.Transaction.CreateTransactions
{
    public class CreateTransactionsCommandHandler(ITransactionRepository _transactionRepository, IUserRepository _userRepository, IUnitOfWork unitOfWork) : ICommandHandler<CreateTransactionsCommand, Result>
    {
        public async Task<Result<Result>> Handle(CreateTransactionsCommand request, CancellationToken cancellationToken)
        {

            var user = await _userRepository.GetAsync(request.Dto.UserId);
            if (user == null)
            {
                return Result.Failure(UserErrors.NotFound);
            }
            var transactions =  PT.Domain.Entities.Transaction.Transactions.CreateTransaction(request.Dto);
            await _transactionRepository.CreateAsync(transactions);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(transactions);
        }
    }
}
