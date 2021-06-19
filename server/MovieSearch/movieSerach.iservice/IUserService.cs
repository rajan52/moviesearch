using movieSearch.Model.dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace movieSerach.iservice
{
    public interface IUserService
    {
        UserDto GetUser(LoginRequest loginRequest);
    }
}
