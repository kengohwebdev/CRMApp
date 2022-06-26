using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Antra.CRMApp.Core.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        [Required, Column(TypeName = "varchar")]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required, Column(TypeName = "varchar")]
        [MaxLength(30)]
        public string Title { get; set; }
        [Required, Column(TypeName = "varchar")]
        [MaxLength(80)]
        public string Address { get; set; }
        [Required, Column(TypeName = "varchar")]
        [MaxLength(20)]
        public string City { get; set; }
        public int RegionId { get; set; }
        public int PostalCode { get; set; }
  
        public string Country { get; set; }
        [Required, Column(TypeName = "varchar")]
        [MaxLength(15)]
        public string Phone { get; set; }
        public Region Region { get; set; }
    }
}
