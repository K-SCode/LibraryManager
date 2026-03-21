using LibraryManager.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryManager.Domain.Entities
{
    public class Book : BaseModel
    {
        public required string Title { get;set;  }
        public required Guid AuthorId { get;set; }
        public Author? Author { get; set; }
        public required string Isbn { get; set; }
        public required string Description { get; set; }
        public required BookStatus Status { get; set; }
        public Guid? CurrentBorrowerId { get; set; }
        public DateTime? ReturnDate { get; set; }
        public required DateTime PublishDate { get; set; }
        public required Guid CategoryId { get; set; }
        public Category? Category { get; set; }
    }
      
}
