using PT.Application.Abstraction;
using PT.Application.Abstraction.Messaging;
using PT.Application.Abstraction.Repositories;
using PT.Domain.Abstraction;
using PT.Domain.Entities.Transaction;
using PT.Domain.Entities.Transaction.Dtos;
using PT.Domain.Entities.User;
using System.Security.Claims;

namespace PT.Application.Features.Query.Transaction.GetTransactions
{
    public sealed class GetTransactionsQueryHandler(IUserRepository _userRepository, ITokenProvider _tokenProvider, ITransactionRepository transactionRepository) : IQueryHandler<GetTransactionsQuery, Result>
    {
        public async Task<Result<Result>> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            var expiredTokenPricipal = _tokenProvider.GetPrincipalFromToken(request.Token);
            if (expiredTokenPricipal == null)
            {
                return Result.Failure(UserErrors.RequestNewToken);
            }
            var claimsUserId = expiredTokenPricipal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            var user = await _userRepository.GetUsersAsync(u => u.Id == claimsUserId);
            if (user == null)
            {
                return Result.Failure(UserErrors.NotFound);
            }
            var transactions = await transactionRepository.GetAllAsync();
            if (!transactions.Any())
            {
                return Result.Failure(TransactionErrors.NotFound);
            }

            var userTransactions = transactions.Where(tr => tr.IsDeleted != false && tr.UserId==user.Id).Select(u => new TransactionDto
            (
                UserId: user.Id,
                UserName: $"{user.FirstName} {user.LastName}",
                Amount: u.Amount,
                CategoryId: u.CategoryId,
                CategoryName: u.Category.Name,
                Date: u.Date,
                Description: u.Description
             )).ToList();
            return Result.Success(userTransactions);
        }
    }
}
