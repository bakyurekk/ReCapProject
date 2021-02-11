using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Ultilities.Results
{
    // Temel Voidler için Başlangıç
    public interface IResult
    {
        bool Success { get;}
        string Message { get; }

    }
}
