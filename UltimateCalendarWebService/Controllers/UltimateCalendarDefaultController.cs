using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UltimateCalendarClassLibrary;
using UltimateCalendarWebService;

namespace UltimateCalendarWebService.Controllers
{
    public class UltimateCalendarDefaultController : ApiController
    {
        IDataHandler dataHandler = new SQLDataHandler(ConfigurationManager.ConnectionStrings["GCPMySqlDB"].ConnectionString);

        [HttpGet]
        public User GetUser(string email,string password)
        {
            User user = new User();
            dataHandler.CredentialsCheck(email, password,out user);
            return user;
        }

        [HttpGet]
        public List<Event> GetEventsForUser(DateTime date, User user)
        {
            return dataHandler.GetEvents(date, user);
        }

        [HttpPost]
        public string RegisterUser(User user)
        {
            return dataHandler.RegisterUser(user);
        }

        [HttpPost]
        public string PostEvent(Event @event)
        {
            try
            {
                dataHandler.AddEvent(@event);
                return "Event successfully added";
            }
            catch (Exception ex)
            {
                return "Couldn't add event " + ex.Message;
            }
        }
    }
}
