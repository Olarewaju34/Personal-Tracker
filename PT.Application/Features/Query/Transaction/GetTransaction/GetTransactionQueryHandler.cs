using PT.Application.Abstraction;
using PT.Application.Abstraction.Messaging;
using PT.Application.Abstraction.Repositories;
using PT.Domain.Abstraction;
using PT.Domain.Entities.Transaction;
using PT.Domain.Entities.Transaction.Dtos;
using PT.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PT.Application.Features.Query.Transaction.GetTransaction
{
    public sealed class GetTransactionQueryHandler(IUserRepository _userRepository, ITransactionRepository _transactionRepository, IUserContext userContext) : IQueryHandler<GetTransactionQuery, Result>
    {
        public async Task<Result<Result>> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUsersAsync(userContext.UserId);
            if (user == null)
            {
                return Result.Failure(UserErrors.NotFound);
            }
            Transactions? dbTransaction = await _transactionRepository.GetTransactions(request.Id);
            if (user.Id != dbTransaction.UserId)
            {
                return Result.Failure(TransactionErrors.Inaccessibility);
            }
            var transaction = new TransactionDto(
                UserId: user.Id,
                UserName: $"{user.FirstName} {user.LastName}",
                Amount: dbTransaction.Amount,
                CategoryId: dbTransaction.CategoryId,
                CategoryName: dbTransaction.Category.Name,
                Date: dbTransaction.Date,
                Description: dbTransaction.Description);
            return Result.Success(transaction);

        }
    }
}
