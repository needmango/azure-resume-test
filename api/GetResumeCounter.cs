using System.Net;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Company.Function;

public class GetResumeCounter
{
    private readonly ILogger _logger;

    public GetResumeCounter(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<GetResumeCounter>();
    }

    [Function("GetResumeCounter")]
    public MyOutputType Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
    [CosmosDBInput(databaseName: "AzureResume", collectionName: 
    "Counter", ConnectionStringSetting = "CosmosDbConnectionString", Id = "1",
            PartitionKey = "1")] Counter counter)
    {

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");
        string jsonString = JsonSerializer.Serialize(counter);
        response.WriteString(jsonString);
        counter.Count =+ counter.Count+1;
        return new MyOutputType()
        {
            UpdatedCounter = counter,
            HttpResponse = response
        };
    }
} 