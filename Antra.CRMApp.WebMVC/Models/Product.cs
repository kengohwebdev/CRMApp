using System.ComponentModel.DataAnnotations;

namespace Antra.CRMApp.WebMVC.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Color is Required")]
        public string Color { get; set; }
    }
}
