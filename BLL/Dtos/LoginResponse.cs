﻿using Data.Models;
using System.Collections.Generic;

namespace BLL.Dtos
{
    public class LoginResponse
    {
        public LoginResponse()
        {
        }
        public User User { get; set; }
    }
}
