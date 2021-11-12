﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AAO_App.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }

        private string Password { get; set; }
    }
}
