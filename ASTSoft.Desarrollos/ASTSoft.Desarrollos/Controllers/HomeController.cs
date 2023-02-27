using ASTSoft.Desarrollos.Models;
using IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Messaging.ViewModels;
using System;
using System.Diagnostics;


namespace ASTSoft.Desarrollos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAST_AgendaDigitalService _agenda;
        private readonly IVehiclesService _vehiculo;

        public HomeController(ILogger<HomeController> logger, IAST_AgendaDigitalService agenda, IVehiclesService vehiculo)
        {
            _logger = logger;
            _agenda = agenda;
            _vehiculo = vehiculo;
        }

        public IActionResult Index(string admin)
        {
            try
            {
                HttpContext.Session.SetString("admin", (admin==null)?"0":"1");
                var response = _vehiculo.GetVehicles();
                return View(response);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        [HttpGet]
        //Get all activities and return as Json
        public ActionResult GetActivities() {
            try
            {
                return Json(_agenda.GetListActivities());
            }
            catch (Exception)
            {
                return Json("");
            }
        }

        [HttpGet]
        public ActionResult GetActivitiesById(int Id) {

            AST_AgendaDigitalView model = new AST_AgendaDigitalView { Id = Id };
            try
            {
                var response = _agenda.GetActivityById(model);
                return Json(response);
            }
            catch (Exception ex)
            {
                return Json(new AST_AgendaDigitalView());
            }

        }

        [HttpDelete]
        //Delete one activity
        public ActionResult DeleteActivities(int id) {
            AST_AgendaDigitalView request = new AST_AgendaDigitalView { Id = id };
            try
            {
                var response = _agenda.DeleteActivities(request);
                return response ? Ok("Solicitud procesada exitosamente") : BadRequest("Ha ocurrido un error en procesar la solicitud");
            }
            catch (Exception ex)
            {
                _logger.LogError("Se presentó un error al tratar de eliminar el registro con el id: " + request.Id, ex);
                return BadRequest("Ocurrio un error en ejecutar el proceso");
            }
        }

        [HttpPut]
        //Update one activity
        public ActionResult UpdateActivities(string cliente, TimeSpan horaInicio, TimeSpan horaFinal, DateTime Fecha, string sucursal, string idVehiculo, int id, bool NuevoCliente) {
            AST_AgendaDigitalView request = new AST_AgendaDigitalView
            {
                Cliente = cliente,
                Fecha = Fecha,
                HoraFinal = horaFinal,
                HoraInicio = horaInicio,
                IdVehiculo = idVehiculo,
                Id = id,
                Sucursal = sucursal,
                NuevoCliente = NuevoCliente
            };

            try
            {
                var response = _agenda.UpdateActivities(request);
                return response ? Ok("Solicitud procesada exitosamente") : BadRequest("Ha ocurrido un error en procesar la solicitud");
            }
            catch (Exception ex)
            {
                _logger.LogError("Se presentó un error al tratar de actualizar el registro con el id: " + request.Id, ex);
                return BadRequest("Ocurrio un error en ejecutar el proceso");
            }
        }

        [HttpPost]
        //Create one activity
        public ActionResult CreateActivities(string cliente, bool NuevoCliente, TimeSpan horaInicio,TimeSpan horaFinal, DateTime Fecha, string sucursal, string idVehiculo) {
            try
            {
                AST_AgendaDigitalView model = new AST_AgendaDigitalView
                {
                    Cliente = cliente,
                    Fecha = Fecha,
                    HoraFinal = horaFinal,
                    HoraInicio = horaInicio,
                    IdVehiculo = idVehiculo,
                    NuevoCliente = NuevoCliente,
                    Sucursal = sucursal
                };

                var response = _agenda.CreateActivities(model);
                return response ? Ok("Solicitud procesada exitosamente") : BadRequest("Ha ocurrido un error en procesar la solicitud");
            }
            catch (Exception ex)
            {
                _logger.LogError("Se presentó un error al tratar de crear una nueva actividad", ex);
                return BadRequest("Ocurrio un error en ejecutar el proceso");
            }
        }

        [HttpPost]
        public ActionResult CreateStucsVehicles(DateTime FechaInicio, DateTime FechaFin, string Vehiculo, string Comentario) {
            try
            {
                if (HttpContext.Session.GetString("admin") != "1")
                {
                    return BadRequest("No se tiene los permisos suficientes para realizar esta acción");
                }

                AST_BloqueVehiculoAgendaView request = new AST_BloqueVehiculoAgendaView { 
                    IdVehiculo = Vehiculo, 
                    FechaFinal = FechaFin, 
                    FechaInicio = FechaInicio,
                    Comentario = Comentario
                };

                var response = _agenda.CreateStuckRequest(request);
                return response ? Ok("Solicitud procesada exitosamente") : BadRequest("Ha ocurrido un error en procesar la solicitud");
            }
            catch (Exception ex)
            {
                _logger.LogError("Se presentó un error al tratar de crear un nuevo bloqueo", ex);
                return BadRequest("Ocurrio un error en ejecutar el proceso");
            }
        }

        [HttpGet]
        public ActionResult GetCustomerById(string id) {
            try
            {
                var response = _agenda.GetCustomerById(id);
                bool valid = response == null || (response.Cliente == null && response.Codigo == null);
                return valid? Json(""): Json(response);
            }
            catch (Exception)
            {
                return Json("");
            }
        }

        [HttpGet]
        public ActionResult GetVehiclesAvailable(string Almacen, DateTime Fecha, TimeSpan HoraInicio, TimeSpan HoraFinal ) {
            try
            {
                VehiclesView model = new VehiclesView { 
                    Almacen = Almacen,
                    Fecha = Fecha,
                    FechaInicio = Fecha.Add(HoraInicio),
                    FechaFin = Fecha.Add(HoraFinal)
                };
                var response = _vehiculo.GetVehiclesByStore(model);
                return Json(response);
            }
            catch (Exception)
            {
                return Json("");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
