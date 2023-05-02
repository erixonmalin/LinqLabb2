using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinqLabb2.Models.Domain
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; } = 0;

        [Required]
        [StringLength(maximumLength: 15, MinimumLength = 1)]
        [Display(Name = "Kursnamn")]
        public string CourseName { get; set; } = default!;

        public virtual ICollection<Class>? Classes { get; set; }
    }
}
