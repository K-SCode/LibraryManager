using LibraryManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Infrastructure.Configurations
{
    public class RentalConfiguration : BaseModelConfiguration<Rental>
    {
        public override void Configure(EntityTypeBuilder<Rental> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.DueDate)
                .IsRequired();
            builder.Property(p => p.RentalDate)
                .IsRequired();
            builder.Property(p => p.IsOverdue)
                .HasDefaultValue(false);
        }
    }
}
