using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Domain.Entities
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
