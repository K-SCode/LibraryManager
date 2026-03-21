using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Domain.Enum
{
    public enum BookStatus
    {
        Available = 0,
        Borrowed,
        Reserved,
        Lost
    }
}
