using System.ComponentModel.DataAnnotations;

namespace LinqLabb2.Models
{
    public class InfoNameViewModel
    {
        [Display(Name = "Roll")]
        public string? TRole { get; set; }

        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        [Display(Name = "Förnamn")]
        public string TFirstName { get; set; }

        [Display(Name = "Efternamn")]
        public string TLastName { get; set; }

        [Display(Name = "Klass")]
        public string ClassName { get; set; } = default!;

        [Display(Name = "Kursnamn")]
        public string CourseName { get; set; } = default!;
    }
}
