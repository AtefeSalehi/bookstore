using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class ErrosResultService<T>:ResultService<T>
    {
        public ErrosResultService(string errorMessage)
        {
            this.IsSuccessfull = false;
            this.ErrorMessage = errorMessage;
        }
    }
}
