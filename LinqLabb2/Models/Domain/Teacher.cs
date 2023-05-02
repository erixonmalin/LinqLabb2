using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinqLabb2.Models.Domain
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeacherId { get; set; } = 0;

        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 1)]
        [Display(Name = "Lärare Förnamn")]
        public string TFirstName { get; set; } = default!;

        [Required]
        [StringLength(maximumLength: 40, MinimumLength = 1)]
        [Display(Name = "Efternamn")]
        public string TLastName { get; set; } = default!;

        public virtual ICollection<Class>? Classes { get; set; }
    }
}
