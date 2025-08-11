# Load Balancing with YARP

## About

This repository presents a comprehensive example project that demonstrates how to implement horizontal scaling and efficient load balancing for ASP.NET Core web applications using YARP (Yet Another Reverse Proxy). The solution includes containerized API instances running with Docker, leveraging Dapper for lightweight and performant data access with PostgreSQL as the database backend. This setup enables seamless distribution of client requests across multiple service instances, ensuring high availability and scalability in modern microservices architectures.

## 🚀 Project Overview

- **ASP.NET Core Web API (Minimal API):** A lightweight and high-performance RESTful API built using ASP.NET Core Minimal APIs, designed for simplicity and efficiency.
- **Dapper:** A lightweight Object-Relational Mapper (ORM) that provides fast and simple data access.
- **PostgreSQL:** A powerful, open-source relational database system used as the backend data store.
- **Docker:** Containerization technology for creating consistent and portable application environments.
- **YARP:** Yet Another Reverse Proxy, used to efficiently distribute incoming traffic across multiple API instances for load balancing and scalability.

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
