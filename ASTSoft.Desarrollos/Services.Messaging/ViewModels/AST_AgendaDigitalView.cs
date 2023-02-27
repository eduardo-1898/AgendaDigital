using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Messaging.ViewModels
{
    public class AST_AgendaDigitalView
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Sucursal { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFinal { get; set; }
        public string Cliente { get; set; }
        public bool NuevoCliente { get; set; }
        public string IdVehiculo { get; set; }

        //Fuera del modelo
        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }
        public string Fechajs { get; set; }
        public string HoraInjs { get; set; }
        public string HoraFinjs { get; set; }
    }
}
