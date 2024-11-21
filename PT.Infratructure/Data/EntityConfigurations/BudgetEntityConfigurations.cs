using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PT.Domain.Entities.Budget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Infratructure.Data.EntityConfigurations
{
    public sealed class BudgetEntityConfigurations : IEntityTypeConfiguration<Budgets>
    {
        public void Configure(EntityTypeBuilder<Budgets> builder)
        {
            builder.ToTable(nameof(Budgets));
            builder.HasKey(b => b.Id);
            builder.HasOne(u=> u.Users).WithMany(bg=>bg.Budgets).HasForeignKey(bg=>bg.UserId);
            builder.Property(bg=>bg.Amount).IsRequired();
        }
    }
}
