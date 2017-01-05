namespace AspDotNetDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [StringLength(8)]
        public string UserId { get; set; }

        [Required]
        [StringLength(10)]
        public string Password { get; set; }

        [Required]
        [StringLength(16)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(16)]
        public string LastName { get; set; }

        [Required]
        [StringLength(1)]
        public string Sex { get; set; }

        [StringLength(11)]
        public string PhoneNumber { get; set; }

        [StringLength(64)]
        public string MailAddress { get; set; }
    }
}
