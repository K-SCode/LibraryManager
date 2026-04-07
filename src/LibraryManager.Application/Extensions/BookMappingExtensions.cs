using LibraryManager.Application.Dtos.Books;
using LibraryManager.Domain.Entities;
using LibraryManager.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using static System.Net.WebRequestMethods;

namespace LibraryManager.Application.Extensions
{
    public static class BookMappingExtensions
    {
        public static CreateBookResponse ToCreateResponse(this Book book)
        {
            return new CreateBookResponse(
                book.Id,
                book.Title,
                book.AuthorId,
                book.Isbn,
                book.Description,
                book.Status,
                book.PublishDate,
                book.CategoryId);
        }
        public static UpdateBookResponse ToUpdateResponse(this Book book)
        {
            return new UpdateBookResponse(
                book.Id,
                book.Title,
                book.AuthorId,
                book.Isbn,
                book.Description,
                book.Status,
                book.PublishDate,
                book.CategoryId);
        }
        public static BookResponse ToBookResponse(this Book book)
        {
            return new BookResponse(
                book.Id,
                book.Title,
                book.AuthorId,
                book.Isbn,
                book.Description,
                book.Status,
                book.PublishDate,
                book.CategoryId);
        }
        public static BookShortResponse ToBookShortResponse(this Book book)
        {
            return new BookShortResponse(
                book.Id,
                book.Title,
                book.AuthorId,
                book.Status,
                book.PublishDate,
                book.CategoryId);
        }

        public static Book ToBook( this CreateBookRequest request)
        {
            return new Book()
            {
                Title = request.Title,
                AuthorId = request.AuthorId,
                Description = request.Description,
                Isbn = request.Isbn,
                Status = request.Status,
                PublishDate = request.PublishDate,
                CategoryId = request.CategoryId,
            };       
        }
        public static Book ToBook(this UpdateBookRequest request)
        {
            return new Book()
            {
                Title = request.Title,
                AuthorId = request.AuthorId,
                Description = request.Description,
                Isbn = request.Isbn,
                Status = request.Status,
                PublishDate = request.PublishDate,
                CategoryId = request.CategoryId,
            };
        }
    }
}
