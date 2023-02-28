# CQRS + MediatR ASP.NET Core API

Proof of Concept of a CQRS pattern, using library MediatR.

Simple API built using ASP.NET Core and MediatR to demonstrate how to easily implement the CQRS pattern in .NET applications.

The example API is very simple, exposing HTTP endpoints through `/api/users` that internally use MediatR to handle requests and responses.

## Frameworks and Libraries
- [ASP.NET Core 6](https://learn.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-6.0);
- [MediatR](https://github.com/jbogard/MediatR) (mediator pattern implementation for .NET);
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) (for data access);
- [SQLite](https://www.sqlite.org/about.html) (for testing purposes);
- [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle) (API documentation).


## API Reference

#### Post all Customers

```http
  POST /api/Customer/Find
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `name`    | `string` | `Find by customer name`    |
| `address` | `string` | `Find by Customer address` |
| `phone`   | `string` | `Find by Customer phone`   |
| `email`   | `string` | `Find by Customer email`   |

#### Get Customer

```http
  GET /api/Customer/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int`    | **Required**. Id of item to fetch |


#### Post Customer

```http
  POST /api/Customer/Insert
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `id`      | `int`    | **Required**. Id           |
| `name`    | `string` | `Customer name`            |
| `address` | `string` | `Customer address`         |
| `phone`   | `string` | `Customer phone`           |
| `email`   | `string` | `Customer email`           |

```http
  POST /api/Customer/Disable/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------        |
| `id`      | `int`    | **Required**. Id of item to fetch |


## How to Test

Run the following commands, in sequence, inside the application directory:

```
dotnet restore
dotnet run
```

Navigate to `https://localhost:7094/swagger/index.html` to check the API documentation and test all endpoints.

## Limitations

The API does not show how to implement distinct databases to read and write data, nor shows advanced synchronization features. The application just shows examples of using MeadiatR and, consequently, the mediator pattern to handle request and responses in a CQRS approach.
