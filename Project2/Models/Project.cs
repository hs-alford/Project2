using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    public class Project
    {
        [Key]
        public string ProjectId { get; set; }
        public string Descripton { get; set; }
        public string CustId { get; set; }
        public int? OrderNumber { get; set; }
        public DateTime DateAdded { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public string? PM_EmpId { get; set; }

        [ForeignKey(nameof(CustId))]
        public Customer Customer { get; set; }
        [ForeignKey(nameof(OrderNumber))]
        public OrderHed? OrderHed { get; set; }
        [ForeignKey(nameof(PM_EmpId))]
        public Employee? ProjectManager { get; set; }

    }
}
