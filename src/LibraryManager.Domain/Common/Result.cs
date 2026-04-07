using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LibraryManager.Domain.Common
{
    public readonly record struct Result<T>(
        bool IsSuccess,
        T Value,
        string Error)
     {
        public static Result<T> Success(T value) => new(true, value, string.Empty);
        public static Result<T> Failure(string error) => new(false, default!, error);   
    }
}
