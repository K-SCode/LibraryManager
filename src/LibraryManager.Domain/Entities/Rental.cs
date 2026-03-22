using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Domain.Entities
{
    public class Rental : BaseModel
    {
        //public required Guid UserId{  get; set; }
        public required Guid BookId { get; set;  }
        public Book? Book { get; set; }
        public required DateTime DueDate { get; set; }
        public required DateTime RentalDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public bool IsOverdue { get; set; }
    }
}
