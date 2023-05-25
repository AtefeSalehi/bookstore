using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Entities;
using Domain.Interfaces;

namespace Service
{
    public class UserService : IUserService
    {
    
        IUserDataAccess userdataacces;

        public UserService(IUserDataAccess userdataacces)
        {
            this.userdataacces = userdataacces;
        }

        public void Registeruser(string username, string password, string fname, string lname)
        {
            var user = new User()
            {
                username = username,
                password = password,
                fname = fname,
                lname = lname

            };
            userdataacces.AddUserToDB(user);
        }
        public User Login(string username, string password)
        {
            bool flag = false;
            User u = new User();
            foreach (var item in userdataacces.SelectUser())
            {
                if (item.username == username && item.password == password)
                {
                    u = item;
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                return u;
            }
            else
                return null;
        }
        public User Finduser(string username)
        {
            return userdataacces.SelectUser().ToList().Find(USER => USER.username == username);
        }


    }
}
