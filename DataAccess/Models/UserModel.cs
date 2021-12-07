using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String PasswordHash { get; set; }
    }
}
