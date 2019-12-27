using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.Models
{
    public class AddRoleModel
    {
        public List<string> roles;
        public string Email { get; set; }
        public string selectedRole { get; set; }
        public AddRoleModel()
        {
            roles = new List<string> { "Administrator", "Manager", "User" };
        }
    }
}