# BackendSchoolSystem-deployed-with-docker-compose-
# SchoolSync API

**A modern, clean, and blazing-fast .NET 8 Backend for managing Students, Courses, Enrollments & School Supplies**

[![.NET 8](https://img.shields.io/badge/.NET-8.0-5C2D91?logo=.net&logoColor=white)](https://dotnet.microsoft.com/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-15-336791?logo=postgresql&logoColor=white)](https://www.postgresql.org/)
[![Docker](https://img.shields.io/badge/Docker-Ready-2496ED?logo=docker&logoColor=white)](https://www.docker.com/)
[![Swagger](https://img.shields.io/badge/Swagger-Ready-85EA2D?logo=swagger&logoColor=black)](http://localhost:5001/swagger)
[![License](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

Modern school management system backend built with **clean architecture**, **CQRS + MediatR**, **Entity Framework Core**, and fully **Dockerized** with docker-compose.

## Features

- Students & Teachers management
- Courses & Class scheduling
- Enrollment system with capacity control
- School supplies/inventory tracking (notebooks, pens, lab equipment, etc.)
- Role-based authorization (Admin, Teacher, Student)
- Audit logs & soft delete
- Health checks & structured logging
- OpenAPI / Swagger UI
- Automated migrations on startup
- Ready for CI/CD

## Tech Stack

| Layer               | Technology                                  |
|---------------------|---------------------------------------------|
| Framework           | .NET 8 (Minimal APIs + Controllers)         |
| Architecture        | Clean Architecture + Vertical Slice         |
| ORM                 | Entity Framework Core 8 + PostgreSQL        |
| Patterns            | CQRS with MediatR, FluentValidation         |
| Auth                | JWT Bearer                                  |
| Containerization    | Docker + docker-compose                     |
| Logging             | Serilog                                     |
| API Documentation   | Swashbuckle (Swagger)                       |

## Quick Start with Docker Compose (Recommended)

```bash
git clone https://github.com/yourusername/SchoolSync.Api.git
cd SchoolSync.Api

cp .env.example .env

docker compose up --build -d
