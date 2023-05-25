using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class User
    {
        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
