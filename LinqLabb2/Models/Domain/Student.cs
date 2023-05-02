using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinqLabb2.Models.Domain
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; } = 0;

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 1)]
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; } = default!;

        [Required]
        [StringLength(maximumLength: 40, MinimumLength = 1)]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; } = default!;

        [Display(Name = "Klass")]
        [ForeignKey(name: "Classes")]
        public int FK_ClassId { get; set; }
        public Class? Classes { get; set; }
    }
}
