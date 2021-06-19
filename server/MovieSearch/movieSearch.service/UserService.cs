using movieSearch.Model.dto;
using movieSerach.iservice;
using System;
using System.Collections.Generic;
using System.Text;

namespace movieSearch.service
{
    public class UserService : IUserService
    {
        public UserDto GetUser(LoginRequest loginRequest)
        {
            UserDto user = new UserDto { Name = "User1", Role =   "admin"  };
            return user;
        }

    }
}
