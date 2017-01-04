namespace CsDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USER_INFO
    {
        [Key]
        [StringLength(8)]
        public string USER_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string PASSWORD { get; set; }

        [Required]
        [StringLength(16)]
        public string FIRST_NAME { get; set; }

        [Required]
        [StringLength(16)]
        public string LAST_NAME { get; set; }

        [Required]
        [StringLength(1)]
        public string SEX { get; set; }

        [StringLength(11)]
        public string PHONE_NUMBER { get; set; }

        [StringLength(64)]
        public string MAIL_ADDRESS { get; set; }
    }
}
