﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Formulär.Models
{
    public enum TypeOfPerson
    {
        Privatperson,
        Företag
    };
    public class Person
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public TypeOfPerson? Type { get; set; }
        public string Email { get; set; }
        public bool Subscriber { get; set; }
        public string Notes { get; set; }
        public DateTime Birthdate { get; set; }
        public string Phone { get; set; }
        public string StreetAddress { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Company { get; set; }
    }
}
