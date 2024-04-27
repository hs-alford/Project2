using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    public class OrderDtl
    {
        public int OrderNumber { get; set; }
        public int OrderLine { get; set; }
        public string PartId { get; set; }
        public string LineDesc { get; set; }
        [Precision(18, 2)]
        public decimal OrderQty { get; set; }
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }
        [DataType(DataType.Currency)]
        public decimal ExtPrice { get; set; }
        public DateTime DateAdded { get; set; }


        public OrderHed OrderHed { get; set; }
        [ForeignKey(nameof(PartId))]
        public Part Part { get; set; }
    }
}
