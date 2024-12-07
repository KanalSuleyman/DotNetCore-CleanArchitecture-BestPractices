# .NET Core Clean Architecture Best Practices

**Status:** Ongoing Reference | **Tech Stack:** .NET Core, EF Core, Clean Architecture

This repository serves as a reference implementation of Clean Architecture principles, best coding practices, and maintainable project structure in a .NET Core environment. It demonstrates how to organize code, maintain separation of concerns, and write testable, scalable, and easily maintainable applications.

## Purpose

The goal of this project is to provide developers with a template or example that:
- **Follows Clean Architecture:** Ensures a clear separation between domain, application logic, and infrastructure concerns.
- **Implements Best Practices:** Adheres to coding standards, SOLID principles, and efficient testing strategies.
- **Is Highly Scalable and Maintainable:** Facilitates adding new features or changing infrastructure components with minimal friction.

## Architecture & Project Structure

The project is organized into separate layers, each with its own responsibility:

/src |-- Domain | |-- Entities | |-- ValueObjects | |-- DomainEvents | -- Exceptions | |-- Application | |-- Common (Behaviors, Interfaces, Mappings) | |-- Features (Commands, Queries, DTOs) | -- Services | |-- Infrastructure | |-- Persistence (EF Core DbContext, Migrations) | |-- Repositories | |-- ExternalIntegrations | -- Logging | |-- WebAPI (Presentation) | |-- Controllers | |-- Filters | |-- Middlewares | -- Models | /tests |-- DomainTests |-- ApplicationTests |-- InfrastructureTests `-- WebAPITests

### Principles Employed
- **Dependency Inversion:** Inner layers depend only on abstractions, not on external frameworks or implementations.
- **Separation of Concerns:** Each layer handles a well-defined responsibility.
- **CQRS (Command and Query Responsibility Segregation):** Commands and Queries are separated for clarity and maintainability.
- **Testability:** By structuring the code into clear layers, each can be tested independently.

## Getting Started

### Prerequisites
- **.NET 8 SDK** (or the current LTS version)
- **SQL Server or PostgreSQL** (or adapt EF Core settings for your chosen DB)
- **Git** for version control

Contributing
This is a reference project. Contributions that enhance examples, add comments, or improve clarity are welcome.

Fork this repo
Create a feature branch (git checkout -b feature/improve-docs)
Commit and push your changes (git commit -m "docs: improve mapping section" and git push)
Open a Pull Request describing your improvements
