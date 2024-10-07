## Apexa Technical Assignment AdvisorAPP project
This project implements Clean Architecture with Domain-Driven Design (DDD) , Inversion of Control (IoC) and CQRS pattern using .NET 8.


**Clean Architecture** is an architectural approach focused on building maintainable, scalable,
and testable applications by dividing the system into distinct layers with clear responsibilities: **Domain, Application, Infrastructure, and Presentation**.


**Domain-Driven Design (DDD)** focuses on creating a deep understanding of the core domain and modeling it accurately using entities, value objects, and aggregates.
It emphasizes using a shared, ubiquitous language among stakeholders and maintaining clear boundaries through bounded contexts. 

**DDD** aims to align software design closely with business needs to handle complexity effectively



***Inversion of Control (IoC)*** is a design principle where the control flow is reversed, 
with dependencies and object creation managed by a framework or container rather than the application code itself. 
This promotes loose coupling, modularity, and easier testing by injecting dependencies rather than having components manage their own dependencies.


**CQRS (Command Query Responsibility Segregation)** is a design pattern that separates operations based on their responsibilities. It divides actions into:

Commands, which modify the state of the application.

Queries, which retrieve data without altering the application's state

## Getting Started :
**Technical Assignment Specifications** :
Download the file '`Technical Assignment - 3 (2).pdf`'

## Technologies Used:
**Design**
* Service Oriented Architecture, Web API
* Clean Architecture
  
**Backend**
* .NET 8 | ASP.NET Core | C# 12
* EF Core 8 for Data Access/ORM
* xUnit for Testing 
  
**Database**
* In-Memory DB Persistence

### Prerequisites

* .NET 8 SDK
* Visual Studio 2022 or later


### Running
#### Windows :
- **Execute `Run-WebAPI.bat`  with the appropriate privileges.
- ** It will expose an HTTP endpoint at 'http://localhost:{REPLACE_GENERATED_PORT}/swagger' 
#### Unix/Linux :
- **Execute `Run-WebAPI.sh`  with the appropriate permissions.
- ** It will expose an HTTP endpoint at 'http://localhost:{REPLACE_GENERATED_PORT}/swagger' 


