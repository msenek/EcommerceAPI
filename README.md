# 🛒 Ecommerce API

A robust, secure, and scalable RESTful API for managing e-commerce operations, built with **.NET** and following Clean Architecture principles. This project demonstrates enterprise-grade practices including JWT authentication, global error handling, automated validation, and comprehensive logging.

## 🚀 Features

- **Secure Authentication & Authorization**: JWT-based auth with BCrypt password hashing and strict resource ownership validation (users can only modify/delete their own products).
- **Automated Validation**: FluentValidation integrated into the ASP.NET Core pipeline for clean controllers and standardized RFC 7807 Problem Details responses.
- **Global Error Handling**: Centralized middleware to gracefully catch and format custom exceptions (`NotFoundException`, `ConflictException`, `BadRequestException`).
- **Advanced Logging**: Structured logging with Serilog (Console + Daily Rolling Files) for easy observability and debugging.
- **Database Management**: Entity Framework Core with PostgreSQL, featuring automatic migrations on startup.
- **Interactive Documentation**: NSwag/Swagger UI configured with JWT Bearer token support for seamless API exploration.
- **Pagination & Filtering**: Optimized product retrieval with server-side pagination and dynamic filtering (by name, min/max price).
- **Unit Testing Ready**: Bootstrapped testing infrastructure using xUnit, Moq, and FluentAssertions.

## 🛠️ Tech Stack

| Category       | Technology                                                                 |
|----------------|----------------------------------------------------------------------------|
| **Framework**  | .NET 10 (ASP.NET Core Web API)                                     |
| **Database**   | PostgreSQL                                                                 |
| **ORM**        | Entity Framework Core                                                      |
| **Auth**       | JWT (JSON Web Tokens), BCrypt.Net                                          |
| **Validation** | FluentValidation                                                           |
| **Logging**    | Serilog                                                                    |
| **Testing**    | xUnit, Moq, FluentAssertions                                               |
| **Documentation**| NSwag / Swagger                                                          |

## 🏗️ Architecture

The project follows a layered architecture to ensure separation of concerns, testability, and maintainability:
- **Controllers**: Handle HTTP requests/responses and model binding.
- **Services**: Contain business logic, ownership validation, and orchestration.
- **Repositories**: Abstract data access logic and interact with EF Core.
- **Validators**: Isolated FluentValidation rules for incoming DTOs.
- **Middleware**: Cross-cutting concerns like Global Exception Handling.

