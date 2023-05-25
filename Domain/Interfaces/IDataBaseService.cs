using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IDataBaseService
    {
        void DataBaseConnection();
        void Dispose();
        void AddUser(User user);
        IEnumerable<object> SelectUser();
       
    }
}
