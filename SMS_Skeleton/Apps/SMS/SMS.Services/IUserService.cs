﻿using SMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.Services
{
    public interface IUserService
    {
        string CreateUser(string username, string email, string password);

        User GetUserOrNull(string username, string password);
    }
}
