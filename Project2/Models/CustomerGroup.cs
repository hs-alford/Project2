using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    public class CustomerGroup
    {
        [Key]
        public string CustomerGroupId { get; set; }
        public string GroupName { get; set; }
        public DateTime DateAdded { get; set; }


        public List<Customer> Customers { get; } = new List<Customer>();
    }
}
