using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    public class Part
    {
        [Key]
        public string PartId { get; set; }
        public string PartDesc { get; set; }
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }
        [Precision(18,2)]
        public decimal QtyInStock { get; set; }
        public DateTime DateAdded { get; set; }


        public List<OrderDtl> OrderDtls { get; } = new List<OrderDtl>();
    }
}
