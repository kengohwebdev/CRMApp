using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Antra.CRMApp.Core.Model
{
    public class CustomerResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Title { get; set; }
        public string Phone { get; set; }

        public string Country { get; set; }

        public RegionModel Region { get; set; }
        public int PostalCode { get; set; }

        public string RegionName { get; set; }
    }
}
