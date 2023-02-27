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
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Services
{
    public class AST_AgendaDigitalService : IAST_AgendaDigitalService
    {

        public ConnectionString ConnectionString { get; }
        public AST_AgendaDigitalQuery QueryActivities = new AST_AgendaDigitalQuery();
        public AST_BloqueoVehiculoAgendaQuery QueryBlocking = new AST_BloqueoVehiculoAgendaQuery();

        public AST_AgendaDigitalService(ConnectionString connectionString) 
        {
            ConnectionString = connectionString;
        }

        public bool CreateActivities(AST_AgendaDigitalView request)
        {
            try
            {
                using IDbConnection db = new SqlConnection(ConnectionString.Value);
                string insertQuery = QueryActivities.createData;
                var result = db.Execute(insertQuery, request);
                db.Close();
                return (result > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateActivities(AST_AgendaDigitalView request)
        {
            try
            {
                using IDbConnection db = new SqlConnection(ConnectionString.Value);
                string insertQuery = QueryActivities.updateData;
                var result = db.Execute(insertQuery, request);
                db.Close();

                return (result > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CreateStuckRequest(AST_BloqueVehiculoAgendaView request)
        {
            try
            {
                using IDbConnection db = new SqlConnection(ConnectionString.Value);
                string insertQuery = QueryBlocking.createData;
                var result = db.Execute(insertQuery, request);
                db.Close();

                return (result > 0);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteActivities(AST_AgendaDigitalView request)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConnectionString.Value))
                {
                    string insertQuery = QueryActivities.deleteData;
                    var result = db.Execute(insertQuery, request);
                    db.Close();

                    return (result > 0);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<AST_AgendaDigitalView> GetListActivities()
        {
            try
            {
                string sql = QueryActivities.getData;
                using var connection = new SqlConnection(ConnectionString.Value);
                connection.Open();
                var response = connection.Query<AST_AgendaDigitalView>(sql, commandType: CommandType.Text).ToList();
                foreach (var item in response)
                {
                    item.FechaFinal = Convert.ToDateTime(item.Fecha).Add(item.HoraFinal).ToString("yyyy-MM-dd HH:mm:ss");
                    item.FechaInicio = Convert.ToDateTime(item.Fecha).Add(item.HoraInicio).ToString("yyyy-MM-dd HH:mm:ss");
                }
                connection.Close();

                return response;
            }
            catch (Exception ex)
            {
                return new List<AST_AgendaDigitalView>();
            }
        }

        public List<AST_BloqueVehiculoAgendaView> GetStuckVehicles()
        {
            try
            {
                string sql = QueryBlocking.getData;
                using var connection = new SqlConnection(ConnectionString.Value);
                connection.Open();
                var response = connection.Query<AST_BloqueVehiculoAgendaView>(sql, commandType: CommandType.Text).ToList();
                connection.Close();

                return response;
            }
            catch (Exception)
            {
                return new List<AST_BloqueVehiculoAgendaView>();
            }
        }

        public AST_AgendaDigitalView GetActivityById(AST_AgendaDigitalView request)
        {
            try
            {
                string sql = QueryActivities.getDataById;
                using var connection = new SqlConnection(ConnectionString.Value);
                connection.Open();
                var response = connection.QuerySingleOrDefault<AST_AgendaDigitalView>(sql, request, commandType: CommandType.Text);
                connection.Close();

                response.Fechajs = response.Fecha.ToString("yyyy-MM-dd");
                response.HoraInjs = response.HoraInicio.ToString();
                response.HoraFinjs = response.HoraFinal.ToString();

                return response;
            }
            catch (Exception ex)
            {
                return new AST_AgendaDigitalView();
            }
        }

        public Customer GetCustomerById(string codclie)
        {
            try
            {
                string sql = QueryActivities.getCustomerById;
                using var connection = new SqlConnection(ConnectionString.Value);
                connection.Open();
                var response = connection.QuerySingleOrDefault<Customer>(sql, new Customer { Cliente = codclie }, commandType: CommandType.Text);
                connection.Close();

                return response;
            }
            catch (Exception ex)
            {
                return new Customer();
            }
        }
    }
}
