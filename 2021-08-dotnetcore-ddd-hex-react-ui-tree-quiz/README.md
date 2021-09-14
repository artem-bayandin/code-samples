# Overview
At the moment, the code is the implementation of one of the test tasks. It should allow a user to 'play' kind of a 'quiz' game with 'yes'/'no' answers to a question. Zero additional requirements, that's why several personal assumptions:
- no 'full-sized' authentication needed: UI simply checks local storage for having a 'user_id' variable, if it does not exist, then a request is sent to API, where a new user is created and its id is sent back to UI and stored in local storage;
- in fact, a quiz is a tree data structure, but storing trees is a complex task, and implementation depends on the business logic; as we have no requirements, then trees are stored as serialized string properties - because a) simple to implement; b) no performance hacks are needed at the moment;
- no tests added - to do it right I need to implement a lot of base test logic, so that tests could be easily added later; just believe me that I have enough experience writing unit tests;
- mix of two approaches - 'ports and adapters' aka 'Hexagonal' and 'CQRS'. A bit more explanation might be found [here](https://herbertograca.com/2017/11/16/explicit-architecture-01-ddd-hexagonal-onion-clean-cqrs-how-i-put-it-all-together/) (my code does not pretend to be a strict copy and/or implementation of principles described in the article, but a sample).

## API
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

## UI
[reserved for description]

### how to run
- node and yarn should be installed;
- check that `REACT_APP_PORT` in .env file is the same as the port you are running server side on;
- `yarn start` to have fun.

### details
#### 2021-08-19:
- cra template;
- folder structure was taken from my head, I don't code React from the very beginning on a daily basis, and I did it just a few times in my career, so don't be too strict.
