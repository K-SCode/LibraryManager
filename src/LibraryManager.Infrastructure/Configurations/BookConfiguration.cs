using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace LibraryManager.Infrastructure.Configurations
{
    public class BookConfiguration 
        : BaseModelConfiguration<Book>
    {
        public override void Configure(
            EntityTypeBuilder<Book> builder)
        {
            base.Configure(builder);

            builder.Property(b => b.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(b => b.Isbn)
                .HasMaxLength(13)
                .IsFixedLength()
                .IsRequired();

            builder.HasIndex(b => b.Isbn)
                .IsUnique();

            builder.Property(b => b.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(b => b.PublishDate)
                .IsRequired();

            builder.Property(b => b.Status)
                .HasConversion<string>()
                .IsUnicode(false)
                .HasMaxLength(30)
                .HasDefaultValue(BookStatus.Available)
                .IsRequired();

            builder.HasOne(b => b.Author)
                .WithMany(b => b.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Category)
                .WithMany(b => b.Books)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
