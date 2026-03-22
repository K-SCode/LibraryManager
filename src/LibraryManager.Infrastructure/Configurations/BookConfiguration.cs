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

            builder.HasOne(book => book.Author)
                .WithMany(author => author.Books)
                .HasForeignKey(book => book.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(book => book.Category)
                .WithMany(category => category.Books)
                .HasForeignKey(book => book.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(book => book.Rentals)
                .WithOne(rental => rental.Book)
                .HasForeignKey(rental => rental.BookId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
