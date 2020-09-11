using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolTemplate.Models
{
    public class PersonModel
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public DateTime Geboortedatum { get; set; }
        [Required(ErrorMessage = "E-mail is verplicht")]
        [EmailAddress(ErrorMessage = "Geen bestaand E-mailadres")]
        public string Email { get; set; }
        public string Telefoonnummer { get; set; }
    }
}