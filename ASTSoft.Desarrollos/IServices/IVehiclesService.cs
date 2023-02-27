using Services.Messaging.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IVehiclesService
    {
        public List<VehiclesView> GetVehicles();

        public List<VehiclesView> GetVehiclesByStore(VehiclesView request);

    }
}
