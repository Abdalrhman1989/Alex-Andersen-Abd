﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AAO_App.Models
{
    public class DepartmentHasEmployee
    {
        [Key]
        public int DepartmentHasEmployeesId { get; set; }
        public int DepId { get; set; }
        public Department Departments { get; set; }
        public int EmppId { get; set; }
        public Employee Employees { get; set; }
        //har opdateret db
    }

}