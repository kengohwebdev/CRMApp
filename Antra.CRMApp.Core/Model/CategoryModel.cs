using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Antra.CRMApp.Core.Entity;

namespace Antra.CRMApp.Core.Model
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [Display(Name = "Enter Name")]
        public string Name { get; set; }

        [Required, Column(TypeName = "varchar")]
        [MaxLength(80)]
        public string Description { get; set; }
    }
}
