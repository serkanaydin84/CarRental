using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        //kullanıcıya data ve mesaj döndürüyor
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }

        //sadece data döndürülüyor
        public SuccessDataResult(T data) : base(data, true)
        {

        }

        //sadece mesaj döndürülüyor. Default dataya denk gelir
        public SuccessDataResult(string message) : base(default, true, message)
        {

        }

        //hiçbirşey döndürülmüyor
        public SuccessDataResult() : base(default, true)
        {

        }
    }
}
