using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Domain.Entities
{
    public class Author : BaseModel
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
