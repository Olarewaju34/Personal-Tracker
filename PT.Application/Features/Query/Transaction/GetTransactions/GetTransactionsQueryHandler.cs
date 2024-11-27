using PT.Application.Abstraction;
using PT.Application.Abstraction.Messaging;
using PT.Application.Abstraction.Repositories;
using PT.Domain.Abstraction;
using PT.Domain.Entities.Transaction;
using PT.Domain.Entities.Transaction.Dtos;
using PT.Domain.Entities.User;
using PT.Domain.Entities.User.Dto;
using System.Security.Claims;

namespace PT.Application.Features.Query.Transaction.GetTransactions
{
    public sealed class GetTransactionsQueryHandler(IUserRepository _userRepository,ITransactionRepository transactionRepository,IUserContext userContext) : IQueryHandler<GetTransactionsQuery, Result>
    {
        public async Task<Result<Result>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
 
            var user = await _userRepository.GetUsersAsync(userContext.UserId);
            if (user == null)
            {
                return Result.Failure(UserErrors.NotFound);
            }
            var transactions = await transactionRepository.GetAllAsync();
            if (!transactions.Any())
            {
                return Result.Failure<TransactionDto>(TransactionErrors.NotFound);
            }

            var userTransactions = transactions.Where(tr => tr.IsDeleted != false && tr.UserId == user.Id).Select(u => new TransactionDto
            (
                UserId: user.Id,
                UserName: $"{user.FirstName} {user.LastName}",
                Amount: u.Amount,
                CategoryId: u.CategoryId,
                CategoryName: u.Category.Name,
                Date: u.Date,
                Description: u.Description
             )).ToList();
            if (userTransactions.Any())
            {
                return Result.Success(userTransactions);
            }
            return Result.Failure(TransactionErrors.NotFound);
        }
    }
}
