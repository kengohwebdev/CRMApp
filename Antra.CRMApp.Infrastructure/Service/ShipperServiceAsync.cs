using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using Antra.CRMApp.Infrastructure.Repository;
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
            ship.Phone = model.Phone;
            ship.Name = model.Name;
            return await shipperRepositoryAsync.InsertAsync(ship);
        }

        public async Task<int> AddShipperAsync(ShipperModel model)
        {
            Shipper ship = new Shipper();
            ship.Name = model.Name;
            ship.Phone = model.Phone;
            
    
            return await shipperRepositoryAsync.InsertAsync(ship);
        }

        public async Task<int> DeleteShipperAsync(int id)
        {
            return await shipperRepositoryAsync.DeleteAsync(id);
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
                    model.Phone = item.Phone;
                    model.Id = item.Id;
                    shipperModels.Add(model);
                }
                return shipperModels;
            }
            return null;
        }

        public async Task<ShipperModel> GetByIdAsync(int id)
        {
            var item = await shipperRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                ShipperModel model = new ShipperModel();
                model.Name = item.Name;
                model.Phone = item.Phone;
                model.Id = item.Id;
                return model;
            }
            return null;
        }

        public async Task<ShipperModel> GetShipperForEditAsync(int id)
        {
            var item = await shipperRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                ShipperModel model = new ShipperModel();
                model.Name = item.Name;
                model.Phone = item.Phone;
                model.Id = item.Id;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateShipperAsync(ShipperModel model)
        {
            Shipper ship = new Shipper();
            ship.Name = model.Name;
            ship.Phone = model.Phone;
            ship.Id = model.Id;
            return await shipperRepositoryAsync.UpdateAsync(ship);

        }
    }
}
