using System.ComponentModel.DataAnnotations;

namespace MVC_1.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lender { get; set; }
        public string Borrower { get; set; }
    }
}
