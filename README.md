# InsureCar API - DOCOsoft Technical Interview Solution

InsureCar is a RESTful Web API built using .NET 8 and C# that simulates a car insurance quote system. This application allows you to manage customers and their insurance quotes through various endpoints. I tried to implement all advanced techniques like SOLID principles, Entity Framework, Dependency Injection, Interfaces and Abstraction, Error handling and Implementation of Unit Tests.

## Features
### Customer Endpoints:

1. Create a new customer
2. Update a customer’s information
3. Get all customers with quotes over a certain amount

### Quote Endpoints:

1. Create a new quote for a customer
2. Get all quotes for a specific model of car
3. Delete a quote

## Data Models
### Customer
* Id: int
* FirstName: string
* LastName: string
* DateOfBirth: DateTime
* Address: string
* Quotes: ICollection<Quote> (Navigation property)

### Quote
* Id: int
* CustomerId: int (foreign key to Customer)
* CarModel: string
* CarYear: int
* Price: decimal
* Customer: Customer (Navigation Property)

## Getting Started
### Prerequisites
1. [**.NET 8 SDK**](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
2. [**SQL Server**](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
