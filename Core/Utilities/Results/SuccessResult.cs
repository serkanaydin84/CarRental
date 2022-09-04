using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        //true sonuç ve mesaj döndürüyor
        public SuccessResult(string message) : base(true, message)
        {

        }

        //sadece sonuç true olarak döndürüyor
        public SuccessResult() : base(true)
        {

        }
    }
}
