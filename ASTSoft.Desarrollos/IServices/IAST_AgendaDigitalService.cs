using Services.Messaging.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IAST_AgendaDigitalService
    {
        //Get all reservations for all the days.
        public List<AST_AgendaDigitalView> GetListActivities();

        public AST_AgendaDigitalView GetActivityById(AST_AgendaDigitalView request);

        //Get all currenly stucks request.
        public List<AST_BloqueVehiculoAgendaView> GetStuckVehicles();

        //delete especific activity
        public bool DeleteActivities(AST_AgendaDigitalView request);

        //update activity
        public bool UpdateActivities(AST_AgendaDigitalView request);

        //create new activity
        public bool CreateActivities(AST_AgendaDigitalView request);

        //create new request of stucks
        public bool CreateStuckRequest(AST_BloqueVehiculoAgendaView request);

        public Customer GetCustomerById(string codclie);

    }
}
