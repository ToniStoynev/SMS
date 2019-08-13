using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SMS.Models
{
    public class User
    {
        public string Id { get; set; }

        [RequiredSis]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [EmailSis]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string CartId { get; set; }
        public Cart Cart { get; set; }
        
    }
}
