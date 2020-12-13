using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Web.Models
{
    public class Country
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Country name cannot exceed 50 characters.")]
        public string Name { get; set; }
    }
}
