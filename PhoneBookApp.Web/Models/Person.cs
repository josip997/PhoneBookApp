using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PhoneBookApp.Web.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public int CityId { get; set; }
        public City City { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Surname cannot exceed 50 characters.")]
        public string Surname { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Phone number cannot exceed 15 characters.")]
        public string Phone { get; set; }

        [Required]
        public GenderChoice? Gender { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0_9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
    public enum GenderChoice
    {
        Male,
        Female
    }
}
