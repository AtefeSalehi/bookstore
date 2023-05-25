using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class ResultService<T>
    {
        public bool IsSuccessfull { get; set; }
        public T Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}
