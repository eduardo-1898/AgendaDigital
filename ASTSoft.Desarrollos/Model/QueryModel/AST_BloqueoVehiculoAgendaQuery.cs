using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.QueryModel
{
    public class AST_BloqueoVehiculoAgendaQuery
    {
        public string createData
        {
            get
            {
                return "INSERT INTO AST_BloqueoVehiculoAgenda(idVehiculo, FechaInicio, FechaFinal, Comentario)" +
                    "VALUES(@idVehiculo, @FechaInicio, @FechaFinal, @Comentario)";
            }
        }

        public string getData
        {
            get
            {
                return "SELECT * FROM AST_BloqueoVehiculoAgenda";
            }
        }

    }
}
