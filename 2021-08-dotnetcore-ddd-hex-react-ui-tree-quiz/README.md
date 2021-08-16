# API
[reserved for description]

### build
Project uses the latest preview version of .Net SDK and runtime. To build and run it you need:
- install SDK 6.0.100-preview.7 (https://dotnet.microsoft.com/download/dotnet/6.0)
- enable preview of SDK (https://docs.microsoft.com/en-us/dotnet/core/tools/sdk-errors/netsdk1045?f1url=%3FappId%3DDev16IDEF1%26l%3DEN-US%26k%3Dk(NETSDK1045)%26rd%3Dtrue#preview-not-enabled
- run 'dotnet restore' before 'dotnet build' if using command line

### details
#### 2021-08-16:
- tried hexagonal architecture - domain is the main part, web api and database are infrastructure, dependencies go inside to domain, although some dependencies between infra project are possible (in fact, a separate Infrastructure.WebApi.IoC might be created with dependencies to Domain and Infrastructure.Persistence, so that WebApi directly knows only about Domain);
- tried to create ports-and-adapters architecture - Domain has In/Out ports, WebApi uses In-ports, Persistence implements adapters for Out-ports;
- tried my loveable Commands and queries - questionable to use it in this way, I don't like, but let it be at the moment. In fact, if decided to use MediatR and FluentValidation everywhere, then ports and adapters might be replaced with requests and handlers, and it will look like a modern 3-layer-app, what is simple and good enough; the same time, there was no need to use commands and queries, as all could be done via interfaces, and possibly interfaces could lead to a DDD with a core Entities which do the job;
- no Automapper added at the moment - mapping of objects between projects should be done with Automapper one day;
- test projects are empty at the moment;
- storing trees is a tricky question and it depends on how it is planned to use the data later. For simplicity, current version serializes trees into string;
- some validation is missed, but general approach is shown;
- records instead of classes used - wanted to try;
- feature based development - in Domain project you may notice how commands and queries are shared across folders;
- no logging;
- no exception handling.

# UI
[reserved for description]

Standard 'cra' template.