using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace AspDotNetDemo.Models
{
    public class User
    {
        public string UserId { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Sex { get; set; }

        public string PhoneNumber { get; set; }

        public string MailAddress { get; set; }
    }
}
