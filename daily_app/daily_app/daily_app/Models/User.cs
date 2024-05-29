using System;
using System.Collections.Generic;
using System.Text;

namespace daily_app.Models
{
    public class User
    {
        public string login { get; set; }
        public string password { get; set; }
        public bool isLogged { get; set; }
    }
}
