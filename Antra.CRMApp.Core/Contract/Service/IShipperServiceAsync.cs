using Antra.CRMApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Core.Contract.Service
{
    public interface IShipperServiceAsync
    {
        Task<IEnumerable<ShipperModel>> GetAllAsync();
        Task<int> AddShipperAsync(ShipperModel model);
        Task<ShipperModel> GetByIdAsync(int id);
        Task<ShipperModel> GetShipperForEditAsync(int id);
        Task<int> UpdateShipperAsync(ShipperModel shipper);
        Task<int> DeleteShipperAsync(int id);
    }

}
