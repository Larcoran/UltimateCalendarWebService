using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using UltimateCalendarClassLibrary;
using UltimateCalendarWebService;

namespace UltimateCalendarWebService.Controllers
{
    public class UltimateCalendarDefaultController : ApiController
    {
        IDataHandler dataHandler = new SQLDataHandler(ConfigurationManager.ConnectionStrings["GCPMySqlDB"].ConnectionString);

        [HttpGet]
        public User GetUser(string email, string password)
        {
            User user = new User();
            dataHandler.CredentialsCheck(email, password, out user);
            return user;
        }

        [HttpGet]
        public List<Event> GetEventsForUser(string date, int userId)
        {
            return dataHandler.GetEvents(Convert.ToDateTime(date), userId);
        }

        [HttpPost]
        public string RegisterUser([FromBody] User userJson)
        {
            return dataHandler.RegisterUser(userJson);
        }

        [HttpPost]
        public string PostEvent([FromBody]Event eventJson)
        {
            return dataHandler.AddEvent(eventJson);
        }
    }
}
