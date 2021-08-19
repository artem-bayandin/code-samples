# API
[reserved for description]

### how to run
Project uses the latest preview version of .Net SDK and runtime. To build and run it you need:
- install SDK 6.0.100-preview.7 (https://dotnet.microsoft.com/download/dotnet/6.0)
- enable preview of SDK (https://docs.microsoft.com/en-us/dotnet/core/tools/sdk-errors/netsdk1045?f1url=%3FappId%3DDev16IDEF1%26l%3DEN-US%26k%3Dk(NETSDK1045)%26rd%3Dtrue#preview-not-enabled
- create a database (current db name is 'Quiz', no user-admin pair required). Do not forget to create this database and apply migrations;
- move to 'Infrastructure.WebApi' forlder, run `dotnet build`, run `dotnet run --urls="https://localhost:6001"`. The port should be the same as `REACT_APP_PORT` in .env in UI project.

### details
#### 2021-08-19:
- ports-and-adapters pattern: Domain has In/Out ports, Infrastructure.WebApi uses In ports from Domain, Infrastructure.Persistence implements Out ports from Domain;
- `?` can WebApi reference Persistense? - in fact, infrastruction projects can reference each other;
- CQRS (my loveable): Domain inside itself has Commands and Queries instead of Entities and Services, each command/query has its own separate validator and handler;
- `?` might be not a good idea to use commands and queries inside just a single project, but I wanted to do both CQRS and framework independent connections between projects - that's why my projects reference each other via interface;
- `?` possible future growth - a) declare usage of MediatR and FluentValidation for inter-project connections to send requests between projects, so that requests are not inter-project requests; b) leave 'interface-d' connections between projects and replace commands with entities and services; 
- no Automapper at the moment - mapping of objects should be done via Automapper one day;
- no test projects at the moment - should be done one day;
- storing trees is a tricky question and it depends on how it is planned to use the data later. For simplicity, current version serializes trees into string;
- heavy validation is missed, but general approach is shown;
- records instead of classes used - wanted to try;
- feature based development - in Domain project you may notice how commands and queries are shared across folders;
- no logging;
- no exception handling.

# UI
[reserved for description]

### how to run
- node and yarn should be installed;
- check that `REACT_APP_PORT` in .env file is the same as the port you are running server side on;
- `yarn start` to have fun.

### details
#### 2021-08-19:
- cra template;
- folder structure was taken from my head, I don't code React from the very beginning on a daily basis, and I did it just a few times in my career, so don't be too strict.
