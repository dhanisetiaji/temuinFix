﻿using System;

namespace temuinFix.Models
{
    public class LoginModel
    {
        public Guid Userid { get; set; }
        public string UserName { get; set; }
        public string Password {get;set;}
        public string Email {get;set;}
        public string Phone {get;set;}
    }
}
