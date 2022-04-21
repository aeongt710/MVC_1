using System.ComponentModel.DataAnnotations;

namespace MVC_1.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Expense Name")]
        public string Name { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Invalid!")]
        public int Amount { get; set; }
    }
}
