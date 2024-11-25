﻿using PT.Application.Abstraction;
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
    public sealed class GetTransactionQueryHandler(IUserRepository _userRepository, ITransactionRepository _transactionRepository, ITokenProvider _tokenProvider) : IQueryHandler<GetTransactionQuery, Result>
    {
        public async Task<Result<Result>> Handle(GetTransactionQuery request, CancellationToken cancellationToken)
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
            var dbTransaction = await _transactionRepository.GetAsync(request.Id);

            var userTransaction = user.Transactions.ToList();

            if (!userTransaction.Contains(dbTransaction))
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