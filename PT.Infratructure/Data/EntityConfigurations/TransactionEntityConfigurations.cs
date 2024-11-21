using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PT.Domain.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Infratructure.Data.EntityConfigurations
{
    internal sealed class TransactionEntityConfigurations : IEntityTypeConfiguration<Transactions>
    {
        public void Configure(EntityTypeBuilder<Transactions> builder)
        {
            builder.ToTable("Transactions");
            builder.HasKey(t => t.Id);
            builder.Property(tr => tr.Amount).IsRequired();
            builder.Property(tr => tr.MoneyFlow).IsRequired();
            builder.HasOne(tr => tr.User).WithMany(t => t.Transactions).HasForeignKey(t => t.UserId);
            builder.HasOne(tr => tr.Category).WithMany(cg => cg.Transactions).HasForeignKey(tr => tr.CategoryId);

        }
    }
}
