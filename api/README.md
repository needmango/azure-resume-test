# Your API lives here
### Azure steps

- Create Azure Cosmos DB Account
- Create Azure Function -> azure-resume\api (C#, .NET Core 6, HttpTrigger, Function)
- In order to run func host start, install az func core tools here: https://github.com/Azure/azure-functions-core-tools#installing
- Create new container in Data Explorer in your new cosmos DB account (Use exxisting, Container id Counter, Partition key /id)
- In your Container -> Counter -> Items, add the following to the json:
```json
    {
        "id": "1",
        "count": 0,
    }
```
- Save and you should be go to go

- Install package in order to work with cosmos DB:
```bash
dotnet add package Microsoft.Azure.WebJobs.Extensions.CosmosDB --version 3.0.10
```
- Add AzureResumeConnectionString to local.settings.json file (Apart of the .gitignore so it won't be pushed to github)

### Azure function steps

- Add a CosmosDB binding to retrieve an item that has an id "1" from the ConnectionString
- Add a binding to update the counter
- Need to remove async for it to work properly
- Remove HTTP starter code
- Update the counter return the counter
