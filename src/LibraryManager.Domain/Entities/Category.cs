using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryManager.Domain.Entities.Model
{
    public class Category : BaseModel
    {
        public required string Name {  get; set; }
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
