using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace LinqLabb2.Models.Domain
{
    public class Class
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassId { get; set; } = 0;

        [Required]
        [StringLength(maximumLength: 5, MinimumLength = 1)]
        [Display(Name = "Klass")]
        public string ClassName { get; set; } = default!;

        [Display(Name = "Lärare")]
        [ForeignKey(name: "Teachers")]
        public int FK_TeacherId { get; set; }
        public virtual Teacher? Teachers { get; set; }

        [Display(Name = "Kurs")]
        [ForeignKey(name: "Courses")]
        public int FK_CourseId { get; set; }
        public virtual Course? Courses { get; set; }
    }
}
