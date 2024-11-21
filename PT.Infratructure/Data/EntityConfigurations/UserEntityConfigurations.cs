using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PT.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Infratructure.Data.EntityConfigurations
{
    internal sealed class UserEntityConfigurations : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.ToTable("users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(200);
            builder.HasIndex(U => U.Email).IsUnique();
            builder.HasMany(u => u.Budgets).WithOne(u => u.Users);
            builder.HasMany(u => u.Transactions).WithOne(tr => tr.User);

        }
    }
}
