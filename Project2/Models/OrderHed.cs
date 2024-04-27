using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    public class OrderHed
    {
        [Key]
        public int OrderNumber { get; set; }
        public string? ProjectId { get; set; }
        public string CustomerId { get; set; }
        [DataType(DataType.Currency)]
        public decimal OrderTotal { get; set; }
        public DateTime DateAdded { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project? Project { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        public List<OrderDtl> OrderDtls { get; } = new List<OrderDtl>();
    }
}
