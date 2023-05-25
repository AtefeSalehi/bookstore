using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class SuccessResultService<T>:ResultService<T>
    {
        public SuccessResultService(T result)
        {
            this.IsSuccessfull = true;
            this.Result = result;
        }
    }
}
