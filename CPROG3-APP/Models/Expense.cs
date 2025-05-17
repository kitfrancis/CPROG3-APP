using System.ComponentModel.DataAnnotations; 

namespace CPROG3_APP.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Value { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
