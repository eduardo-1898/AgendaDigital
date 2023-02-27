using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Messaging.ViewModels
{
    public class AST_BloqueVehiculoAgendaView
    {
        public int Id { get; set; }
        public string IdVehiculo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Comentario { get; set; }
    }
}
