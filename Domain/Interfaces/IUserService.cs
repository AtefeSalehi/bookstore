using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        void Registeruser(string username, string password, string fname, string lname);
        User Login(string username, string password);
        User Finduser(string username);
    }
}
