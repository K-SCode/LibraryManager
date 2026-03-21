using LibraryManager.Domain.Entities;
using LibraryManager.Infrastructure.Generators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace LibraryManager.Infrastructure.Configurations
{
    public abstract class BaseModelConfiguration<TEntity>
        : IEntityTypeConfiguration<TEntity> where TEntity : BaseModel
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                   .HasValueGenerator<SequentialGuidV7Generator>()
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.CreatedAt)
                   .HasDefaultValueSql("GETUTCDATE()")
                   .IsRequired();
        }
    }
}
