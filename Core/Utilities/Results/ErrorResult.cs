using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        //false sonuç ve mesaj döndürüyor
        public ErrorResult(string message) : base(false, message)
        {

        }

        //sadece sonuç false olarak döndürüyor
        public ErrorResult() : base(false)
        {

        }
    }
}
