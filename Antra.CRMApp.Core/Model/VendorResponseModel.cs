using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Model
{
    public class VendorResponseModel
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Mobile { get; set; }
        public string EmailId { get; set; }
        public bool IsActive { get; set; }

        public RegionModel Region { get; set; }

        public string RegionName { get; set; }


    }
}
