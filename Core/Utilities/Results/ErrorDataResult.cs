using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        //kullanıcıya data ve mesaj döndürüyor
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }

        //sadece data döndürülüyor
        public ErrorDataResult(T data) : base(data, false)
        {

        }

        //sadece mesaj döndürülüyor. Default dataya denk gelir
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        //hiçbirşey döndürülmüyor
        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
