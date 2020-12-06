using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Web.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required]
        public int CountryId { get; set; }

        public Country Country { get; set; }

        //[Required]
        //[MaxLength(6, ErrorMessage = "City cypher cannot exceed 6 characters.")]
        //public string Cypher { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "City name cannot exceed 50 characters.")]
        public string Name { get; set; }

        
    }

}
