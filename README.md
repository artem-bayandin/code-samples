Here I will collect samples of architectures I used to, to use it within my future projects.

# clean-architecture-dotnetcore-api
Web API project built using .Net Core 3.1, EF 3.1. Design - Clean Architecture. Technologies used:
- .net core 3.1
- ef 3.1
- mediatr
- fluent validation
- automapper
- swagger

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
