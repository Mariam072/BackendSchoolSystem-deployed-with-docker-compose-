# School Management System API  
**A Clean, Professional .NET 8 CRUD Backend with SQL Server**  
**Students • Courses • School Supplies – Fully Dockerized & Ready to Impress**

[![.NET 8](https://img.shields.io/badge/.NET-8.0-5C2D91?logo=.net&logoColor=white)](https://dotnet.microsoft.com/)
[![SQL Server 2022](https://img.shields.io/badge/SQL%20Server-2022-CC2927?logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/sql-server)
[![Entity Framework Core](https://img.shields.io/badge/EF%20Core-8.0-blue)](https://learn.microsoft.com/ef/core/)
[![Docker](https://img.shields.io/badge/Docker%20Compose-Ready-2496ED?logo=docker&logoColor=white)](https://www.docker.com/)
[![Swagger](https://img.shields.io/badge/Swagger-UI-85EA2D?logo=swagger&logoColor=black)](https://localhost:5001/swagger)
[![License: MIT](https://img.shields.io/badge/License-MIT-brightgreen.svg)](LICENSE)

A beautiful, well-structured, educational-purpose school management backend built with modern .NET 8 practices.  
Perfect for portfolios, job interviews, learning Clean Architecture, or as a rock-solid starter template.

## Project Overview

This system demonstrates clean CRUD operations using **Entity Framework Core** with **three independent tables** sharing an educational theme:

- No foreign keys or navigation properties (intentional design)
- Full data validation with meaningful error messages
- Real-world business rules applied at the model level
- Clean separation of concerns
- Ready for production-like deployment with **Docker Compose + SQL Server 2022**

## Entities & Business Rules

### Students
| Field       | Type   | Validation Rules                                   |
|-------------|--------|----------------------------------------------------|
| StudentId   | int    | Primary Key, Auto-increment                        |
| FullName    | string | Required                                           |
| Age         | int    | Must be between 5 and 18 inclusive                 |
| GradeLevel  | string | Must be "1st", "2nd", ..., "12th" only             |

### Courses
| Field        | Type   | Validation Rules                                          |
|--------------|--------|-----------------------------------------------------------|
| CourseId     | int    | Primary Key, Auto-increment                               |
| CourseName   | string | Required                                                  |
| RoomNumber   | string | Must contain both letters and numbers (e.g., A101, LAB12) |
| MaxCapacity  | int    | Must be between 10 and 30 inclusive                       |

### School Supplies
| Field             | Type    | Validation Rules                                      |
|-------------------|---------|-------------------------------------------------------|
| ItemId            | int     | Primary Key, Auto-increment                           |
| ItemName          | string  | Required                                              |
| Price             | decimal | Cannot be negative                                    |
| QuantityAvailable | int     | ≥ 0 (items with 0 are hidden in main list endpoint)   |

## API Endpoints (Full interactive Swagger UI)

| Method | Endpoint                     | Description                                      |
|--------|------------------------------|--------------------------------------------------|
| GET    | `/api/students`              | List all students                                |
| GET    | `/api/students/{id}`         | Get student by ID                                |
| POST   | `/api/students`              | Create new student                               |
| PUT    | `/api/students/{id}`         | Update student                                   |
| DELETE | `/api/students/{id}`         | Delete student                                   |
|        |                              |                                                  |
| GET    | `/api/courses`               | List all courses                                 |
| GET    | `/api/courses/{id}`          | Get course by ID                                 |
| POST   | `/api/courses`               | Create course                                    |
| PUT    | `/api/courses/{id}`          | Update course                                    |
| DELETE | `/api/courses/{id}`          | Delete course                                    |
|        |                              |                                                  |
| GET    | `/api/supplies`              | Available supplies only (Quantity > 0)           |
| GET    | `/api/supplies/all`          | All supplies including out-of-stock (admin view) |
| GET    | `/api/supplies/{id}`         | Get supply by ID                                  |
| POST   | `/api/supplies`              | Add new supply item                              |
| PUT    | `/api/supplies/{id}`         | Update supply                                    |
| DELETE | `/api/supplies/{id}`         | Remove supply item                               |

## Project Structure
├── Models/
│   ├── Student.cs
│   ├── Course.cs
│   └── SchoolSupply.cs
├── Data/
│   └── SchoolDbContext.cs
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
├── Dockerfile
├── docker-compose.yml
└── README.md
