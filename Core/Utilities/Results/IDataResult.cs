using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public interface IDataResult<T> : IResult
    {
        //bu interface'in içinde T türünde bir Data olacak
        T Data { get; }
    }
}
