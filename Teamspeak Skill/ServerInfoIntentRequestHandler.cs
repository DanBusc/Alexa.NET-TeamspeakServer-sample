using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.RequestHandlers;
using Alexa.NET.Response;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamspeak
{
    public class ServerInfoIntentRequestHandler : IAlexaRequestHandler
    {

        public bool CanHandle(AlexaRequestInformation<SkillRequest> information)
        {
            return information.SkillRequest.Request is IntentRequest intent
                && intent.Intent.Name == "GetServerinfo";
        }

        public async Task<SkillResponse> Handle(AlexaRequestInformation<SkillRequest> information)
        {

            var servers = await Helper.GetServerinfo();

            if (servers?.Count == 0)
            {
                return ResponseBuilder.Tell("No data could be determined. The server may not be accessible. Check this and come back later.");
            }
            else
            {
                var sb = new StringBuilder("The server " + servers.First().Name + " is " + servers.First().Status + ". ");

                var serverinfo = string.Empty;
                string clients = (servers.First().ClientsOnline - 1).ToString();
                
                if (clients == "1")
                    clients = "one user is";
                else
                    clients = clients + "users are";
                
                if (Convert.ToInt32(servers.First().Uptime.TotalDays) <= 1)
                    sb.Append("The server has been online for one day. ");
                else
                    sb.Append("The server has been online for " + Convert.ToInt32(servers.First().Uptime.TotalDays) + " days. ");

                sb.Append("currently " + clients + " logged in. ");
                sb.Append("Anything else I can do?");

                var repromptBody = new Reprompt();
                repromptBody.OutputSpeech = new SsmlOutputSpeech(Helper.ssmlString(sb.ToString()));
                return ResponseBuilder.Ask(new SsmlOutputSpeech(Helper.ssmlString(sb.ToString())), repromptBody);
            }
        }



    }
}
