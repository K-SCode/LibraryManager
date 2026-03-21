using LibraryManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Infrastructure.Configurations
{
    public class AuthorConfiguration : BaseModelConfiguration<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            base.Configure(builder);

            builder.Property(b => b.FirstName)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(b => b.LastName)
                .HasMaxLength(60)
                .IsRequired();

            builder.HasIndex(b => new {b.FirstName,b.LastName});
        }
    }
}
