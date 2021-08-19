Here I will collect samples of architectures I used to, to use it within my future projects.

# 2021-08-dotnetcore-ddd-hex-react-ui-tree-quiz
## state: started August, 2020, alpha version ready
[view code](https://github.com/artem-bayandin/code-samples/tree/master/2021-08-dotnetcore-ddd-hex-react-ui-tree-quiz)
Simple quiz game - choose answers for questions, get some result, save result.
Web API on .Net 6 preview, ports and adapters, CQRS.
React 17 UI with Router and Redux-Toolkit.
Mode description inside the folder `2021-08-dotnetcore-ddd-hex-react-ui-tree-quiz`.

# 2021-08-WIP-nodejs-nest-hexagonal
## state: started in August'2021, suspended
[view code](https://github.com/artem-bayandin/code-samples/tree/master/2021-08-WIP-nodejs-nest-hexagonal)
Web API project built using Node.js and Nest.js. Design - DDD, Hexagonal (ports and adapters).

# 2020-03-clean-architecture-dotnetcore-api
## state: started on March, 2020, suspended
[view code](https://github.com/artem-bayandin/code-samples/tree/master/2020-03-WIP-clean-architecture-dotnetcore-api)
Web API project built using .Net Core 3.1, EF 3.1. Design - Clean Architecture. Technologies used:
- .net core 3.1
- ef 3.1
- mediatr
- fluent validation
- automapper
- swagger
- azure build pipelines added

Further improvements (TODOs):
- samples of more complex queries and commands, some di and so on
- internal services (both interface and implementation are in the same assembly)
- external services (interface and implementation are in different assemblies)
- decorators (logging, etc)
- context refactoring (interface, repos (?), UoW)
- some usefull staff from other projects (crosscutting, infrastructure) (tg.Domain.Extensions.ValidatorExtensions, ijsonid, performance pipeline behavior)
- user service (interface in domain, implementation in webapi)
- api middlewares (corelationid, userid, exception handling)
- IoC
- event log (separate project to handle specific domain commands)
- camelCaseErrors for property names when validation fails
- remove ef core 3.1 (I will find that issue with .Include() which is not that one from previous versions)
- base handlers (?)
- refactor dependencies to get rid of maximum unnecessary staff
- microservices (split current or add one more, plus communication between them)
- deploy to azure (containerization)
- database migrations, deploy to azure
- authentication and authorization with azure ad
- error logging (nlog), error handling (elmah)
- nswag, openapi
- tests
