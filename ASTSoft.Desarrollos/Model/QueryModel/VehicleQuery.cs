using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.QueryModel
{
    public class VehicleQuery
    {
        public string getData
        {
            get
            {
                return "SELECT Almacen, SerieLote FROM serielote WHERE Almacen like '%05' AND Existencia >=1";
            }
        }

        public string getDataByStore
        {
            get
            {
                return "SELECT * FROM SerieLote slt " +
                    "WHERE Almacen = @Almacen " +
                    "AND Existencia >=1 " +
                    "AND SerieLote not in( " +
                    "   SELECT IdVehiculo " +
                    "   FROM AST_BloqueoVehiculoAgenda " +
                    "   WHERE FechaInicio >= @Fecha " +
                    "   OR FechaFinal <= @Fecha " +
                    "   AND idVehiculo = slt.SerieLote) " +
                    "AND SerieLote not in ( " +
                    "   SELECT IdVehiculo " +
                    "   FROM AST_AgendaDigital " +
                    "   WHERE IdVehiculo = slt.SerieLote " +
                    "   AND( @FechaInicio > CAST(Fecha as datetime) + CAST(HoraInicio as datetime) " +
                    "       AND @FechaInicio <CAST(Fecha as datetime) + CAST(HoraFinal as datetime)" +
                    "   ) " +
                    "   OR( @FechaFin > CAST(Fecha as datetime) + CAST(HoraInicio as datetime)" +
                    "       AND @FechaFin < CAST(Fecha as datetime) + CAST(HoraFinal as datetime) " +
                    "   ) " +
                    "   OR( @FechaInicio = CAST(Fecha as datetime) + CAST(HoraInicio as datetime) " +
                    "       AND @FechaFin > CAST(Fecha as datetime) + CAST(HoraFinal as datetime)" +
                    "   )" +
                    "   OR( @FechaInicio = CAST(Fecha as datetime) + CAST(HoraInicio as datetime) " +
                    "       AND @FechaFin = CAST(Fecha as datetime) + CAST(HoraFinal as datetime)" +
                    "   ))";
            }
        }
    }
}
