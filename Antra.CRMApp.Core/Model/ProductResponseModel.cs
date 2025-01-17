﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Antra.CRMApp.Core.Model
{
    public class ProductResponseModel
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string Name { get; set; }

        [Required]
        public int VendorId { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int QuantityPerUnit { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public int UnitsInStock { get; set; }
        [Required]
        public int UnitsOnOrder { get; set; }
        [Required]
        public int ReorderLevel { get; set; }
        [Required]
        public bool Discontinued { get; set; }

        public VendorResponseModel Vendor { get; set; }

        public CategoryModel Category { get; set; }

        public string VendorName { get; set; }

        public string CategoryName { get; set; }

    }
}
