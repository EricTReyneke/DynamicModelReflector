# DynamicModelReflector

Welcome to the DynamicModelReflector project, a data access layer designed in accordance with SOLID principles and equipped for Dependency Injection. This framework offers a alternative akin to ADO.Net, facilitating dynamic data interactions using ADO.NET in the backend.

## Problem Statement

The aim is to develop a data access layer that allows for automated query generation and populates provided Plain Old CLR Objects (POCO) with data from the database, addressing inefficiencies and complexities found in traditional approaches.

## Project Goals

### Initial Phase

- **CRUD Operations**: Develop full CRUD (Create, Read, Update, Delete) functionality within the DataModelReflector.
- **Performance and Clarity**: Enhance the efficiency and clarity of query construction and execution.

### Disclaimer

- **DataModelReflectorLinq**: This was my first go at creating a dynamic query builder with ADO.Net as the backend database connector. Please note the I created a more modern approach with my [DynamicModelReflectorLinQ](https://github.com/EricTReyneke/DynamicModelReflectorLinQ).

## Example Usage

Here’s how to effectively utilize the DynamicModelReflector to manage database operations:

```csharp
// Initialize the components required by the reflector
IDataAccess dataReceiver = new SqlDataAccess();
IQueryBuilder queryBuilder = new SqlQueryBuilder();
IDataModelReflector reflector = new SqlDataModelReflector(dataReceiver, queryBuilder);

// Setting up conditions to load data
IAndOrConditions sqlAndOrConditions = new SqlAndOrConditions() {
    AndConditions = new SqlAndConditions() {
        IsNulls = new SqlIsNull[] { new SqlIsNull("Level") },
        IsNotNulls = new SqlIsNotNull[] { new SqlIsNotNull("Name") }
    }
};

// Load categories based on the specified conditions
IEnumerable<Category> categories = reflector.Load<Category>(sqlAndOrConditions);
