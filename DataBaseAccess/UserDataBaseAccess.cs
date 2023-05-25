using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Providers.Entities;
using Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Domain.Entities;
using User = Domain.Entities.User;
using StructureMap;
using Sitecore.FakeDb;
using XAct.Library.Settings;

namespace DataBaseAccess
{
    public class UserDataBaseAccess:IUserDataAccess
    {
       
        public void AddUserToDB(User user)
        {
            using (DataBaseAccess database=new DataBaseAccess())
            {
                SqlCommand cmd = new SqlCommand($"insert into User (Fname,Lname,Username,Passwoed)"+$"values('{user.fname}','{user.lname}','{user.username}','{user.password}')",database.conn);
                cmd.ExecuteNonQuery();
            }
        }
        public IEnumerable<User> SelectUser()
        {
            using (DataBaseAccess database = new DataBaseAccess())
            {
                List<User> users = new List<User>();
                SqlCommand cmd = new SqlCommand("select * from User",database.conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User()
                    {
                        fname = reader.GetString(0),
                        lname = reader.GetString(1),
                        username = reader.GetString(2),
                        password = reader.GetString(3),
                    });
                }
                return users;
            }
                
        }
    }
}
