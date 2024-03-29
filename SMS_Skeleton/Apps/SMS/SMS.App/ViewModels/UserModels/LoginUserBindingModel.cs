﻿using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.App.ViewModels.UserModels
{
    public class LoginUserBindingModel
    {
        [RequiredSis]
        [StringLengthSis(5, 20, "Username should be between 5 and 20 characters")]
        public string Username { get; set; }

        [RequiredSis]
        [StringLengthSis(6, 20, "Password should be between 5 and 20 characters")]
        public string Password { get; set; }
    }
}
