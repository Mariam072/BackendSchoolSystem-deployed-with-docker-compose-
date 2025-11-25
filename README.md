# School Management System API  
**Clean .NET 8 CRUD Backend with SQL Server – Students • Courses • School Supplies**

[![.NET 8](https://img.shields.io/badge/.NET-8.8.0-5C2D91?logo=.net&logoColor=white)](https://dotnet.microsoft.com/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-CC2927?logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/sql-server)
[![Entity Framework Core](https://img.shields.io/badge/EF%20Core-8.0-512BD4?logo=nuget)](https://learn.microsoft.com/ef/core/)
[![Docker](https://img.shields.io/badge/Docker%20Compose-Ready-2496ED?logo=docker&logoColor=white)](https://www.docker.com/)
[![Swagger](https://img.shields.io/badge/Swagger-Ready-85EA2D?logo=swagger&logoColor=black)](https://localhost:5001/swagger)
[![License](https://img.shields.io/badge/License-MIT-brightgreen.svg)](LICENSE)

A clean, educational-purpose School Management API built with **clean architecture principles**, full validation, and deployed via **Docker Compose with SQL Server 2022**.

No foreign keys – three fully independent entities with real-world business rules.

## Entities & Validation Rules

### Students
| Field       | Type   | Rules                                    |
|-------------|--------|------------------------------------------|
| StudentId   | int    | PK, Identity                             |
| FullName    | string | Required                                 |
| Age         | int    | 5 ≤ Age ≤ 18                             |
| GradeLevel  | string | Must be "1st", "2nd", ..., "12th"         |

### Courses
| Field        | Type   | Rules                                                 |
|--------------|--------|-------------------------------------------------------|
| CourseId     | int    | PK, Identity                                          |
| CourseName   | string | Required                                              |
| RoomNumber   | string | Must contain letters + numbers (e.g. A101, LAB12)     |
| MaxCapacity  | int    | 10 ≤ Capacity ≤ 30                                    |

### School Supplies
| Field             | Type    | Rules                                      |
|-------------------|---------|--------------------------------------------|
| ItemId            | int     | PK, Identity                               |
| ItemName          | string  | Required                                   |
| Price             | decimal | ≥ 0                                        |
| QuantityAvailable | int     | ≥ 0 (GET /supplies hides zero-stock items) |

## Project Structure
