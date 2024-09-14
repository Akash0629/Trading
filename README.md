# Trading

# Steps to Run the Project =>
1. Run the API Project
2. You will see a swagger page
3. You will be able to see the three API's
	a. CreatePosition Api =>
		   i.Description => this api will create the positions 
		   ii.Property => TradeId 
					  SecurityCode
					  Quantity
					  Action ( 1=> Buy, 2=> Sell)
					  Operation (1=> Insert, 2=> Update, 3=> Cancel)
		   iii.Response => It will retun a boolean flag if it's insered succefully will retun as true else false
		   iv. On validation failure will return 500 status code with validation error message.
		   
	b. GetLatestPosition Api=>
	       i. Description =>  this api wil retun the current trading SecurityCode and latest Quantity

    c. GetAllPositions Api=>
	       i. Description =>  this api will retun All the positions added in the database.
		   
		   

 # Techical Stack =>
        1. ASP.NET Core 8.0 (with .NET 8.0)
		2. Entity Framewok Core
        3. AutoMapper
        4. MediatR
        5. FluentValidation
        6. Xunit
        7. FluentAssertions
		8. Moq
        8. Angular	


 #Design Patterns
    1. Domain Driven Design
	2. CQRS
	3. Mediator
	4. Repository 
	5. Dependency injection
   
 #Project Architecure
    1. Trading.API is the presentatation layer
    2. Trading.Application is the Application or Use Case layer where we write the business logic and often grouped into Commands and Queries, following CQRS
    3. Trading.Domain is the project where we have kept all our entities which will be helpful when we are communicating with database or can leverage Domain Events to communicate changes to other parts of the system.
    4. Trading.Infrastructure is the project which we will be responsible for implementing the repository class and it is concerned with EF, Files, Email, Web Services, Azure/AWS/GCP, etc is Infrastructure
   
	   