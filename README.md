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

![Screenshot of Customer Model](https://github.com/Pushkar-Deshmane/InsureCar/blob/master/InsureCar.Api/img/Customer%20Model.PNG "Customer Model")


### Quote
* Id: int
* CustomerId: int (foreign key to Customer)
* CarModel: string
* CarYear: int
* Price: decimal
* Customer: Customer (Navigation Property)

![Screenshot of Quote Model](https://github.com/Pushkar-Deshmane/InsureCar/blob/master/InsureCar.Api/img/quote%20Model.PNG "Quote Model")


## Getting Started
### Prerequisites
1. [**.NET 8 SDK**](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
2. [**SQL Server**](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Installation
1. **Clone the repository:**
    ```
    git clone https://github.com/Pushkar-Deshmane/InsureCar.git
    cd InsureCar
    ```
2. **Restore dependencies:**

    `dotnet restore`
   
4. **Update database connection string:**

    Update the connection string in appsettings.json located in the InsureCar.Api project to point to your SQL Server instance.

6. **Run database migrations:**

   `dotnet ef migrations add InitialCreate --project InsureCar.Api`
   
   `dotnet ef database update --project InsureCar.Api`

   (This can also be done from visual studio instead of commanf prompt using Package Manager Console and EF migration commands)

7. **Run the application:**

    `dotnet run --project InsureCar.Api`

***Let's asuume the API will be running at https://localhost:44385. your port number could be different here***

## Using Swagger

Swagger is available for API documentation and testing. Open your browser and navigate to https://localhost:44385/swagger to view and test the endpoints.

## Testing with Postman

To test the API using Postman, follow these steps:

**1. Create a Customer:**

* URL: https://localhost:44385/api/customer
* Method: POST
* Body:
  ```
      {
          "firstName": "Pushkar",
          "lastName": "Deshmane",
          "dateOfBirth": "1980-01-01T00:00:00Z",
          "address": "123 Cork St"
      }
  ```

**2. Update a Customer:**

* URL: https://localhost:44385/api/customer/1
* Method: PUT
* Body:
  ```
      {
          "id": 1,
          "firstName": "Pushkar",
          "lastName": "Deshmane",
          "dateOfBirth": "1980-01-01T00:00:00Z",
          "address": "456 Cork main St"
      }
  ```

**3. Get Customers with Quotes Over a Certain Amount:**

* URL: https://localhost:44385/api/customer/quotes-over/1000
* Method: GET

**4. Create a Quote:**

* URL: https://localhost:44385/api/quote
* Method: POST
* Body:
  ```
      {
          "customerId": 1,
          "carModel": "BMW",
          "carYear": 2019,
          "price": 1500.00
      }
  ```
**5. Get Quotes by Car Model:**

* URL: https://localhost:44385/api/quote/car-model/BMW
* Method: GET

**6. Delete a Quote:**

* URL: https://localhost:44385/api/quote/1
* Method: DELETE

## Running Unit Tests

Unit tests are implemented using xUnit and Moq. To run the tests, use the following command:

`dotnet test`

## Possible Improvements

We can implement UnitOfWork in this .NET API Application to make it decoupled

## Resources Used

* [https://www.w3schools.com/cs/cs_interface.php](https://www.w3schools.com/cs/cs_interface.php)
* [https://try.stackoverflow.co/explore-teams?utm_source=adwords&utm_medium=ppc&utm_campaign=kb_teams_search_brand_emea-dach&_bt=657236278306&_bk=stack+overflow&_bm=p&_bn=g&gad_source=1&gclid=CjwKCAjw7s20BhBFEiwABVIMrdrlIgI9WvCXtGyRvt3BPxIitKRkTyhuT6qNaz3kKVRH9pY33ITZTRoCSqAQAvD_BwE](https://try.stackoverflow.co/explore-teams?utm_source=adwords&utm_medium=ppc&utm_campaign=kb_teams_search_brand_emea-dach&_bt=657236278306&_bk=stack+overflow&_bm=p&_bn=g&gad_source=1&gclid=CjwKCAjw7s20BhBFEiwABVIMrdrlIgI9WvCXtGyRvt3BPxIitKRkTyhuT6qNaz3kKVRH9pY33ITZTRoCSqAQAvD_BwE)
* [https://www.udemy.com/certificate/UC-c6422dad-f7d5-43e8-9c64-3103714dd2f1/](https://www.udemy.com/certificate/UC-c6422dad-f7d5-43e8-9c64-3103714dd2f1/)
     
