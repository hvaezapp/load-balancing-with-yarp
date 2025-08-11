# Load Balancing with YARP

## About

This repository presents a comprehensive example project that demonstrates how to implement horizontal scaling and efficient load balancing for ASP.NET Core web applications using YARP (Yet Another Reverse Proxy). The solution includes containerized API instances running with Docker, leveraging Dapper for lightweight and performant data access with PostgreSQL as the database backend. This setup enables seamless distribution of client requests across multiple service instances, ensuring high availability and scalability in modern microservices architectures.

## 🚀 Project Overview

- ASP.NET Core Web API: A RESTful API built with ASP.NET Core.
- Dapper: A lightweight Object-Relational Mapper (ORM) for data access.
- PostgreSQL: The relational database backend.
- Docker: Containerization of the application for consistent environments.
- YARP: A reverse proxy for distributing incoming traffic across multiple API instances.

## 🛠️ Prerequisites

Ensure you have the following installed:

- .NET SDK (version 9.0)
- Docker Desktop

## 📦 Project Setup

1. Clone the Repository

   ```bash
   git clone https://github.com/hvaezapp/load-balancing-with-yarp.git
   cd load-balancing-yarp
   
2. Restore Dependencies

   ```bash
   dotnet restore
   
3. Build the Solution

   ```bash
   dotnet build
   
4. Docker Integration 

   ```bash
   docker-compose up
