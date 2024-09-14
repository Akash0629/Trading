# Trading Project
	
# Steps to Run the Project =>
1. Run the API Project
2. You will see a swagger page
3. You will be able to see the three API's
	- GetLatestPosition Api=>
		- Description: This API will create the positions
		- Property:
			- TradeId
			- SecurityCode
			- Quantity
			- Action (1=> Buy, 2=> Sell)
			- Operation (1=> Insert, 2=> Update, 3=> Cancel)
		- Response: It will return a boolean flag. If it's inserted successfully, it will return true; otherwise, false.
		- On validation failure, it will return a 500 status code with a validation error message.

	- GetLatestPosition Api=>
		- Description: This API will return the current trading SecurityCode and latest Quantity.

	- GetAllPositions Api=>
		- Description: This API will return all the positions added in the database.

# Techical Stack =>
- ASP.NET Core 8.0 (with .NET 8.0)
- Entity Framewok Core
- AutoMapper
- MediatR
- FluentValidation
- Xunit
- FluentAssertions
- Moq
- Angular

# Design Patterns
1. Domain Driven Design
2. CQRS
3. Mediator
4. Repository 
5. Dependency injection

# Project Architecure
1. Trading.API is the presentatation layer
2. Trading.Application is the Application or Use Case layer where we write the business logic and often grouped into Commands and Queries, following CQRS
3. Trading.Domain is the project where we have kept all our entities which will be helpful when we are communicating with database or can leverage Domain Events to communicate changes to other parts of the system.
4. Trading.Infrastructure is the project which we will be responsible for implementing the repository class and it is concerned with EF, Files, Email, Web Services, Azure/AWS/GCP, etc is Infrastructure

		   
	   