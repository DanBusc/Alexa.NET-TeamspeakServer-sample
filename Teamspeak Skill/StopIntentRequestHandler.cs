using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.RequestHandlers;
using Alexa.NET.Response;
using System.Threading.Tasks;

namespace Teamspeak
{
    public class StopIntentRequestHandler : IAlexaRequestHandler
    {

        public bool CanHandle(AlexaRequestInformation<SkillRequest> information)
        {
            return information.SkillRequest.Request is IntentRequest intent
                && (intent.Intent.Name == "AMAZON.StopIntent" || intent.Intent.Name == "AMAZON.CancelIntent");
        }

        public Task<SkillResponse> Handle(AlexaRequestInformation<SkillRequest> information)
        {
            return Task.FromResult(ResponseBuilder.Tell("bye bye"));
        }
    }
}
