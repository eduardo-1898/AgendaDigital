using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Messaging.ViewModels
{
    public class VehiclesView
    {
        public string SerieLote { get; set; }
        public string Almacen { get; set; }
        public DateTime Fecha { get; set; }
        public string IdVehiculo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
