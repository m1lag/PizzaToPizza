# 🍕 PizzaToPizza API

Backend service for the **PizzaToPizza** project built with **ASP.NET Core Web API** and **PostgreSQL**.
The project provides a REST API for pizza catalog management, users, orders, promo codes, and JWT authentication.

---

## 📌 Project Overview

PizzaToPizza API is a backend service designed for integration with a separate **React frontend**.

### Main Features

- 👤 User registration and login
- 🔐 JWT authentication
- 🛡️ Role system (`User` / `Admin`)
- 🍕 Pizza catalog management
- 📂 Categories
- 🛒 Orders system
- 🎁 Promo codes
- 📘 Swagger API documentation
- 🗄️ PostgreSQL database
- ⚙️ Entity Framework Core

---

## 🛠 Technologies Used

- ASP.NET Core Web API
- C#
- Entity Framework Core
- PostgreSQL
- JWT Bearer Authentication
- Swagger / OpenAPI
- BCrypt password hashing
- REST API architecture

---

## 📂 Project Structure

```text
PizzaToPizza/
│
├── Controllers/      # API Controllers
├── Services/         # Business logic
├── Models/           # Database entities
├── Dtos/             # Data Transfer Objects
├── Data/             # DbContext
├── Migrations/       # EF Core migrations
├── Program.cs        # App configuration
└── appsettings.json  # Settings
```

---

## 🔐 Authentication & Roles

### User

Can:

- Register / Login
- View pizzas
- Create orders
- View own orders

### Admin

Can:

- Add / Edit / Delete pizzas
- Manage categories
- Manage promo codes
- View all orders

---

## 📡 Main API Endpoints

### Authentication

```http
POST /api/users/register
POST /api/users/login
```

### Pizzas

```http
GET    /api/pizzas
GET    /api/pizzas/{id}
POST   /api/pizzas        (Admin)
PUT    /api/pizzas/{id}   (Admin)
DELETE /api/pizzas/{id}   (Admin)
```

### Categories

```http
GET    /api/categories
POST   /api/categories    (Admin)
PUT    /api/categories/{id}
DELETE /api/categories/{id}
```

### Orders

```http
POST /api/orders
GET  /api/orders/my
GET  /api/orders          (Admin)
```

### Promo Codes

```http
GET /api/promocodes
POST /api/promocodes      (Admin)
```

---

## 🗄 Database

**Database Engine:** PostgreSQL  
**ORM:** Entity Framework Core

### Seed Data Included

- Categories
- Pizza menu

---

## 🚀 Running the Project

### 1️⃣ Clone Repository

```bash
git clone <repository-url>
cd PizzaToPizza
```

### 2️⃣ Configure Database

Edit `appsettings.json`

```json
"ConnectionStrings": {
  "DefaultConnection": "your_postgresql_connection"
}
```

### 3️⃣ Apply Migrations

```bash
dotnet ef database update
```

### 4️⃣ Run Project

```bash
dotnet run
```

---

## 📘 Swagger Documentation

After launch:

```text
https://localhost:{port}/swagger
```

Use **Authorize** button to insert JWT token.

---

## 🔑 Example Login Response

```json
{
  "token": "eyJhbGciOiJIUzI1NiIs..."
}
```

Use token in requests:

```http
Authorization: Bearer YOUR_TOKEN
```

---

## 🧱 Architecture Improvements

This project was refactored to use:

- Controllers + Services separation
- DTO pattern
- JWT security
- Validation attributes
- Role authorization
- Clean API responses

---

## 📈 Future Improvements

- Global Error Middleware
- Refresh Tokens
- Email verification
- Docker support
- Unit tests
- Deployment

---

## 👨‍💻 Author

Backend refactoring, architecture improvements, JWT integration, API modernization.

---

## 📄 License

Educational project.

