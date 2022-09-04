using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool Success { get; }
        public string Message { get; }

        // this(success)'in anlamı;
        // Success = success; bu kodu her iki constractor'da da yazmamış gerekiyordu ancak DRY (Don't repeat yoruself) göre
        // birinci constractor'da yukarıdaki kodu yazmadık ve
        // success'i ikinci constratctor'da gönderdik ve çalıştır dedik. Böylece;
        // Success success; kodunu her iki constractor'da da çalıştırmış olduk
        // Developer bu sayede ister sadece sonucu döndürür ya da hem sonucu hem de mesaj döndürür
        public Result(bool success, string message) : this(success)
        {
            //normalde getter lar readonly dir ancak;
            //realonly ler constractor dan set edilebilir
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }
    }
}
