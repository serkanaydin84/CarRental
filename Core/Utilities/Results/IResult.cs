using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // Temel voidler için başlangıç
    public interface IResult
    {
        //yapılan işin sonucu true / false tutar
        bool Success { get; }

        //kullanıcıya geri döndürülecek mesaj true/false olması farketmez
        //ÖRN: araç eklendi, araça eklenemedi, bağlantı hatası...
        string Message { get; }
    }
}
