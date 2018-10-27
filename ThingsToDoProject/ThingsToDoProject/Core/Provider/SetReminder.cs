using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThingsToDoProject.Core.Interface;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace ThingsToDoProject.Core.Provider
{
    public class SetReminder : ISetReminder
    {
        private readonly IHttpClientFactory _httpClientFactory;
        IConfiguration _iconfiguration;

        public SetReminder(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _iconfiguration = configuration;

        }

        public void SetReminderForIternary(string phoneNumber, string placeId, string name, string distance, string storeNumber, string GoogleUrl)
        {
            var authToken = _iconfiguration["TwilioAuthToken"];
            var accountSid = _iconfiguration["TwilioAccountSid"];

            TwilioClient.Init(accountSid, authToken);
            string number = "whatsapp:+91" + phoneNumber;
            try
            {

                var message = MessageResource.Create(
                    body: "Hello you have set a reminder for" + name + "/br distance to this place from airport is" + distance + "/br Phone No :" + storeNumber + "/br Google Map Link:" + GoogleUrl + "",
                    from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
                    to: new Twilio.Types.PhoneNumber(number)
                );

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
         
        }
        public void SetReminderForAll(string phoneNumber)
        {
            var authToken = _iconfiguration["TwilioAuthToken"];
            var accountSid = _iconfiguration["TwilioAccountSid"];

            TwilioClient.Init(accountSid, authToken);
            string number = "whatsapp:+91" + phoneNumber;
            try
            {

                var message = MessageResource.Create(
                    body: "Hello, this is the reminder you have set for your upcoming trip click on following link to browse more ",
                    from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
                    to: new Twilio.Types.PhoneNumber(number)
                );

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        
        }
    }
}


