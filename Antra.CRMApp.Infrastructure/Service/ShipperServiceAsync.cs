using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Infrastructure.Service
{
    public class ShipperServiceAsync:IShipperServiceAsync
    {
        private readonly IShipperRepositoryAsync shipperRepositoryAsync;
        public ShipperServiceAsync(IShipperRepositoryAsync _shipperRepositoryAsync)
        {
            shipperRepositoryAsync = _shipperRepositoryAsync;
        }

        public async Task<int> AddCategoryAsync(ShipperModel model)
        {
            Shipper ship = new Shipper();
            ship.Id = model.Id;
            ship.Phone = model.Phone;
            ship.Name = model.Name;
            return await shipperRepositoryAsync.InsertAsync(ship);
        }

        public async Task<int> AddShipperAsync(ShipperModel model)
        {
            Shipper ship = new Shipper();
            ship.Name = model.Name;
            ship.Phone = model.Phone;
            ship.Id = model.Id;
    
            return await shipperRepositoryAsync.InsertAsync(ship);
        }

        public async Task<IEnumerable<ShipperModel>> GetAllAsync()
        {
            var collection = await shipperRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<ShipperModel> shipperModels = new List<ShipperModel>();
                foreach (var item in collection)
                {
                    ShipperModel model = new ShipperModel();
                    model.Name = item.Name;
                    model.Id = item.Id;
                    shipperModels.Add(model);
                }
                return shipperModels;
            }
            return null;
        }
    }
}
