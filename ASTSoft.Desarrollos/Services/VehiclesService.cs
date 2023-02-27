using Dapper;
using IServices;
using Model.QueryModel;
using Services.Messaging.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class VehiclesService : IVehiclesService
    {

        public ConnectionString ConnectionString { get; }
        public VehicleQuery QueryVehicle = new VehicleQuery();

        public VehiclesService(ConnectionString connectionString)
        {
            ConnectionString = connectionString;
        }

        public List<VehiclesView> GetVehicles()
        {
            try
            {
                string sql = QueryVehicle.getData;
                using var connection = new SqlConnection(ConnectionString.Value);
                connection.Open();
                var response = connection.Query<VehiclesView>(sql, commandType: CommandType.Text).ToList();
                connection.Close();

                return response;
            }
            catch (Exception)
            {
                return new List<VehiclesView>();
            }
        }

        public List<VehiclesView> GetVehiclesByStore(VehiclesView request)
        {
            try
            {
                string sql = QueryVehicle.getDataByStore;
                using var connection = new SqlConnection(ConnectionString.Value);
                connection.Open();
                var response = connection.Query<VehiclesView>(sql, request, commandType: CommandType.Text).ToList();
                connection.Close();

                return response;
            }
            catch (Exception ex)
            {
                return new List<VehiclesView>();
            }
        }
    }
}
