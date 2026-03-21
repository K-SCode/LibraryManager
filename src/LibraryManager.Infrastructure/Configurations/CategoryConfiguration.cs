using LibraryManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Infrastructure.Configurations
{
    public class CategoryConfiguration : BaseModelConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.Property(b => b.Name)
                .HasMaxLength(40)
                .IsRequired();
        }
    }
}
