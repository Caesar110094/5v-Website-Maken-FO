using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolTemplate.Models
{
  public class PersonModel
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public DateTime Geboortedatum { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }