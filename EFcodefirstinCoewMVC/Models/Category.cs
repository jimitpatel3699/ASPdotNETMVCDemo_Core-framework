using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EFcodefirstinCoewMVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required ]
        [MaxLength(100)]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Custom Error msg DisplayOrder range mustbe in 1..100")]
        public int DisplayOrder { get; set; }
    }
}
