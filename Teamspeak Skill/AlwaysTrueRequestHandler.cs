using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.RequestHandlers;
using Alexa.NET.Response;
using System.Threading.Tasks;

namespace Teamspeak
{
    public class AlwaysTrueRequestHandler : IAlexaRequestHandler
    {

        public bool CanHandle(AlexaRequestInformation<SkillRequest> information)
        {
            return true;
        }

        public Task<SkillResponse> Handle(AlexaRequestInformation<SkillRequest> information)
        {
            return Task.FromResult(ResponseBuilder.Ask(new SsmlOutputSpeech(Helper.ssmlString("Sorry, I didn't get that. Please say it again.")), new Reprompt() { OutputSpeech = new PlainTextOutputSpeech("I didn't get that. Please say it again.") }));

        }
    }
}
