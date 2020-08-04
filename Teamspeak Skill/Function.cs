using Alexa.NET.Request;
using Alexa.NET.RequestHandlers;
using Alexa.NET.Response;
using Amazon.Lambda.Core;
using System.Threading.Tasks;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Teamspeak
{
    public class Function
    {
      
        public async Task<SkillResponse> FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            SkillResponse response = new SkillResponse
            {
                Response = new ResponseBody()
            };


            var pipeline = new AlexaRequestPipeline();
            pipeline.RequestHandlers.Add(new LaunchRequestHandler());
            pipeline.RequestHandlers.Add(new GetClientsIntentRequestHandler());
            pipeline.RequestHandlers.Add(new ServerInfoIntentRequestHandler());
            pipeline.RequestHandlers.Add(new HelpIntentRequestHandler());
            pipeline.RequestHandlers.Add(new StopIntentRequestHandler());
            pipeline.RequestHandlers.Add(new AlwaysTrueRequestHandler());

            return await pipeline.Process(input, context);
        }
    }
}
