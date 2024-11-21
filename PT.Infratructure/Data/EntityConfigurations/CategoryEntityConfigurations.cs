using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PT.Domain.Entities.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT.Infratructure.Data.EntityConfigurations
{
    public sealed class CategoryEntityConfigurations : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.ToTable(nameof(Categories));
            builder.HasKey(cg => cg.Id);
            builder.Property(cg => cg.Name).IsRequired();
            builder.HasMany(cg => cg.Transactions).WithOne(tr => tr.Category);

        }
    }
}
