using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    public class Customer
    {
        [Key]
        public string CustId { get; set; }
        public string Name { get; set; }
        public string CustomerGroupId { get; set; }
        public DateTime DateAdded { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }

        [ForeignKey(nameof(CustomerGroupId))]
        public CustomerGroup CustomerGroup { get; set; }
        public List<Project> Projects { get; } = new List<Project>();
    }
}
