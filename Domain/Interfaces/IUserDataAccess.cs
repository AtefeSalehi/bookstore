using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IUserDataAccess
    {
        void AddUserToDB(User user);
        IEnumerable<User> SelectUser();
    }
}
