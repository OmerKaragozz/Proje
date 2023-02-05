using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Security
{
    public  class UserRepository
    {
        public static List<User> Users = new()
        {
            new() { UserName = "omer_Admin", Password = "MyPass_w0rd", GivenName = "Omer", SurName = "Karagoz", Role = "Administrator"},
            new() { UserName = "elliot_Standart", Password = "ThisPass_w0rd", GivenName = "Elliot", SurName = "Alderson", Role = "Standart"}
        };
    }
}
