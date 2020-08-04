using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.RequestHandlers;
using Alexa.NET.Response;
using System.Linq;
using System.Threading.Tasks;

namespace Teamspeak
{
    public class GetClientsIntentRequestHandler : IAlexaRequestHandler
    {
       
        public bool CanHandle(AlexaRequestInformation<SkillRequest> information)
        {
            return information.SkillRequest.Request is IntentRequest intent 
                && intent.Intent.Name == "GetClients";
        }

        public async Task<SkillResponse> Handle(AlexaRequestInformation<SkillRequest> information)
        {
            
            var clients = await Helper.GetClients();
            if (clients.Count == 0)
            {
                return ResponseBuilder.Tell(new SsmlOutputSpeech(Helper.ssmlString("There's nobody online.")));
            }
            else if (clients.Count == 1)
            {
                return ResponseBuilder.Tell(new SsmlOutputSpeech(Helper.ssmlString("There's one person on the server. " + Helper.NormalizeClients(clients).First().NickName + ".")));
            }
            else
            {
                string users = "";
                clients = Helper.NormalizeClients(clients);
                int i = 0;
                foreach (var user in clients)
                {
                    if (i < clients.Count - 1)
                        users += user.NickName + ",";
                    else
                        users += " and " + user.NickName + ",";

                    i++;
                }


                return ResponseBuilder.Tell(new SsmlOutputSpeech(Helper.ssmlString("There are several people online. " + users)));
            }
        }

        

    }
}
