# About Library System

This mini-project was built following a Clean Architecure and implementing the Repository Pattern with Unit of Work using .NET 5.0

## Projects included
This solution follows the Clearn Architecture, you can find the following projects:

- ***Core*** – This is like the Application + Domain layers combined. It holds the Entities and Interfaces. It does not depend on any other project in the solution.
- ***Infrastructure*** – Data access layer using Entity Framework Core – Code First Apporach to interact with our Database (create databaes, seed data, create stored procedures).
The purpose is we can implement another data access layer (using ADO.NET or Dapper) and easily swap it with this project. Here is where Dependency Inversion comes to play.
It depends on Core project.
- ***SystemLibrary*** – This is like the presentation layer of the entire solution. It depends on Infrastructure project.

## My contact information
Mustafa Albaghdadi<br />
Software Engineer<br />
Phone:  +963-935836143 / +971 55 477 3113<br />
Email: dev.mustafa.albaghdadi@outlook.com<br />
