# .NET Core Clean Architecture - N-Layered Best Practices

This project implements **Clean Architecture** principles in a .NET Core application, following **N-Layered** design best practices. The structure ensures a high level of separation of concerns, maintainability, scalability, and testability for future extensions.

## Table of Contents
1. [Project Structure](#project-structure)
2. [Technologies Used](#technologies-used)
3. [Design Principles](#design-principles)
4. [Features](#features)

## Project Structure

The solution is divided into several layers that align with Clean Architecture:

1. **Domain**:
    - Contains the core business logic and domain entities.
    - No dependencies on other layers.
    - Examples:
      - `SampleEntity`, `SampleEntityCategory`
      - `CriticalException`, `ConnectionStringOption`

2. **Application**:
    - Contains application logic like use cases, services, and contract definitions.
    - It holds the interfaces for the repository and service layers.
    - Examples:
      - `ICacheService`, `ISampleEntityRepository`, `IUnitOfWork`
      - `SampleEntityService`, `SampleEntityDto`

3. **Infrastructure**:
    - Implements repositories, data access, and external service integrations.
    - Examples:
      - `GenericRepository`, `SampleEntityRepository`
      - `CacheService`, `UnitOfWork`

4. **Presentation (API)**:
    - Exposes APIs and handles HTTP requests.
    - It includes controllers, filters, and middleware to interact with the application layer.
    - Examples:
      - `SampleEntitiesController`, `GlobalExceptionHandler`
      - `CachingExtensions`, `SwaggerExtensions`

5. **Core**:
    - Contains shared code used across layers.
    - Defines essential contracts like DTOs and request/response models.

## Technologies Used
- **.NET Core 8**
- **Entity Framework Core** (for data access)
- **FluentValidation** (for model validation)
- **AutoMapper** (for object-to-object mapping)
- **Swagger/OpenAPI** (for API documentation)
- **Memory Caching** (for performance optimization)

## Design Principles

### Clean Architecture
- **Separation of Concerns**: Each layer focuses on a single responsibility.
- **Dependency Inversion**: Inner layers (Domain) do not depend on outer layers.
- **Testability**: The architecture allows for easier unit and integration testing.

## Features
- **CRUD Operations**: Full set of CRUD operations for `SampleEntity` and `SampleEntityCategory`.
- **Caching**: Integrated caching for optimized data retrieval.
- **Global Exception Handling**: Comprehensive error handling and logging system.
- **Fluent Validation**: Model validation with custom rules.
- **Swagger Documentation**: Auto-generated documentation with OpenAPI for the RESTful API.
