using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Ultilities.Results
{
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
