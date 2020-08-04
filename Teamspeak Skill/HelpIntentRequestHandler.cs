using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.RequestHandlers;
using Alexa.NET.Response;
using System.Threading.Tasks;

namespace Teamspeak
{
    public class HelpIntentRequestHandler : IAlexaRequestHandler
    {

        public bool CanHandle(AlexaRequestInformation<SkillRequest> information)
        {
            return information.SkillRequest.Request is IntentRequest intent
                && (intent.Intent.Name == "AMAZON.HelpIntent");
        }

        public Task<SkillResponse> Handle(AlexaRequestInformation<SkillRequest> information)
        {
            return Task.FromResult(ResponseBuilder.Ask(new SsmlOutputSpeech(Helper.ssmlString("For a list of all connected users ask, who is online? If you want information about the server, say serverinfo.")), new Reprompt() { OutputSpeech = new PlainTextOutputSpeech("For a list of all connected users ask, who is online? If you want information about the server, say Serverinfo.") }));
        }
    }
}
