using Application.Abstract;
using Application.Security;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Concrete
{
    public class UserService : IUserService
    {
        public User Get(UserLogin userLogin)
        {
           User user = UserRepository.Users.FirstOrDefault( x => x.UserName.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase) && x.Password.Equals(userLogin.Password));

            return user;
        }
    }
}
