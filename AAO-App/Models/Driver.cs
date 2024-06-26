﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace AAO_App.Models
{
    public class Driver
    {

        [Key]
        public int DriverId { get; set; }
        public int CityId { get; set; }
        public City Cities { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "BirthDate:")]
        public DateTime Birthday { get; set; }
        public string Password { get; set; }
        public int IsValidated { get; set; }
        public Byte[] ProfileImage { get; set; }
        //public IFormFile file { get; set; }
    }
}
