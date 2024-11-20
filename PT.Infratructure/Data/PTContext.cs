﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PT.Domain.Abstraction;
using PT.Domain.Entities.Budget;
using PT.Domain.Entities.Category;
using PT.Domain.Entities.Transaction;
using PT.Domain.Entities.User;

namespace PT.Infratructure.Data
{
    public sealed class PTContext(
    DbContextOptions<PTContext> options,
    IHttpContextAccessor httpContextAccessor,
    IMediator mediator
    ) : IdentityDbContext(options), IUnitOfWork
    {
        public DbSet<Users> Users;
        public DbSet<Transactions> Transactions;
        public DbSet<Budgets> Budgets;
        public DbSet<Categories> Categories;

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateSoftDeleteStatuses();
            this.AddAuditInfo(httpContextAccessor);
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateSoftDeleteStatuses();
            this.AddAuditInfo(httpContextAccessor);
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private const string IsDeletedProperty = "IsDeleted";

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues[IsDeletedProperty] = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues[IsDeletedProperty] = true;
                        break;
                }
            }

        }
    }
}
