using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.QueryModel
{
    public class AST_AgendaDigitalQuery
    {
        public string createData {
            get {
                return "INSERT INTO AST_AgendaDigital(Fecha, Sucursal, HoraInicio, HoraFinal, Cliente, NuevoCliente, IdVehiculo)" +
                    "VALUES(@Fecha, @Sucursal, @HoraInicio, @HoraFinal, @Cliente, @NuevoCliente, @IdVehiculo)";
            }
        }

        public string updateData {
            get {
                return "UPDATE AST_AgendaDigital SET Fecha = @Fecha, Sucursal = @Sucursal, HoraInicio = @HoraInicio, " +
                    "HoraFinal = @HoraFinal, Cliente = @cliente, NuevoCliente = @NuevoCliente, IdVehiculo = @IdVehiculo WHERE Id = @id";
            }
        }
        public string deleteData { 
            get {
                return "DELETE FROM AST_AgendaDigital WHERE id = @id";    
            }
        }

        public string getData
        {
            get {
                return "SELECT *, DATEADD(SECOND, DATEPART(SECOND,HoraInicio), CAST(Fecha AS datetime)) as FechaInicio, " +
                    "DATEADD(SECOND, DATEPART(SECOND,HoraFinal), CAST(Fecha AS datetime)) as FechaFinal " +
                    "FROM AST_AgendaDigital";
            }
        } 

        public string getDataById {
            get
            {
                return "SELECT *, DATEADD(SECOND, DATEPART(SECOND,HoraInicio), CAST(Fecha AS datetime)) as FechaInicio, " +
                    "DATEADD(SECOND, DATEPART(SECOND,HoraFinal), CAST(Fecha AS datetime)) as FechaFinal " +
                    "FROM AST_AgendaDigital WHERE id = @id";
            }
        }

        public string getCustomerById
        {
            get
            {
                return "SELECT Nombre as Cliente, Cliente as Codigo FROM CTE WHERE cliente = @cliente " +
                    "OR RFC= @cliente " +
                    "OR CURP = @cliente";
            }
        }

    }
}
