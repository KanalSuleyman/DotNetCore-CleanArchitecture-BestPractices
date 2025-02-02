# DotNetCore-NLayered-And-CleanArchitecture-BestPractices

This repository provides a comprehensive reference implementation of Clean Architecture principles tailored for .NET Core applications. It demonstrates best practices in structuring projects to achieve maintainability, scalability, and testability by adhering to concepts such as separation of concerns, dependency inversion.

## Purpose

The primary objective of this project is to offer developers a template that:

- **Follows Clean Architecture**: Ensures a clear separation between domain, application logic, and infrastructure concerns.
- **Implements Best Practices**: Adheres to coding standards, SOLID principles, and efficient testing strategies.
- **Is Highly Scalable and Maintainable**: Facilitates adding new features or changing infrastructure components with minimal friction.

## Architecture & Project Structure

The project is organized into distinct layers, each with its own responsibility:

- **Domain**:
  - Entities
  - ValueObjects
  - DomainEvents
  - Exceptions
- **Application**:
  - Common (Behaviors, Interfaces, Mappings)
  - Features (Commands, Queries, DTOs)
- **Infrastructure**:
  - Persistence (EF Core DbContext, Migrations)
  - Repositories
  - ExternalIntegrations
  - Logging
- **WebAPI (Presentation)**:
  - Controllers
  - Filters
  - Middlewares
  - Models

This structure promotes a clean separation of concerns, making the application easier to maintain and scale.

## Principles Employed

The following principles are integral to the architecture:

- **Dependency Inversion**: Inner layers depend only on abstractions, not on external frameworks or implementations.
- **Separation of Concerns**: Each layer handles a well-defined responsibility.
- **CQRS (Command and Query Responsibility Segregation)**: Commands and Queries are separated for clarity and maintainability.
- **Testability**: By structuring the code into clear layers, each can be tested independently.
