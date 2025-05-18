Product & Category API

This project is developed using C#. It  implements a RESTful API for managing products and categories using .NET 8 and Entity Framework Core with a Code-First approach. The system allows each product to belong to multiple categories (2 or 3), and it supports pagination for listing products and categories. The database used is SQLite, and the API is documented using Swagger for easy exploration.

Key Features

Category API:

    Create,  update, and delete categories.

    Get a paginated list of categories.

    Retrieve category details by ID.

Product API:

    Create products with multiple categories.

    Retrieve a paginated list of products with their assigned categories.

    Retrieve product details by ID.

    Update products and their categories.

    Delete products.

Technology Stack

Tools and Libraries Used
    .NET 8

    Entity Framework Core

    SQLite

    Swagger

    Fluent Validation

Postman Collection

Created a Postman collection to test the API endpoints. You can import this collection into your Postman application to quickly test and interact with the API operations.


