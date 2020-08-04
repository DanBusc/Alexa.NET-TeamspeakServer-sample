using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.RequestHandlers;
using Alexa.NET.Response;
using System.Threading.Tasks;

namespace Teamspeak
{
    public class LaunchRequestHandler : IAlexaRequestHandler
    {
        public bool CanHandle(AlexaRequestInformation<SkillRequest> information)
        {
            return information.SkillRequest.Request is LaunchRequest;
        }

        public Task<SkillResponse> Handle(AlexaRequestInformation<SkillRequest> information)
        {
                return Task.FromResult(ResponseBuilder.Ask("Hi, how can I help you?", new Reprompt("how can I help you?")));
        }
        
    }

}
