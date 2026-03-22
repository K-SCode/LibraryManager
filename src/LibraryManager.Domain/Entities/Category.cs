using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Domain.Entities
{
    public class Category : BaseModel
    {
        public required string Name { get; set; }
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
