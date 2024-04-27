using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    public class MenuItem
    {
        [Key]
        public string MenuItemId { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public int Order { get; set; }
        public string? Color { get; set; }
        public string Parent { get; set; }
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public bool? Enabled { get; set; }
        public string? SecurityID { get; set; }
        public string? Icon { get; set; }
        public string? Dashboard { get; set; }
        public string? Customization { get; set; }
        public string? Report { get; set; }

    }
}
