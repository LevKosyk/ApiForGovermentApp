# 🇺🇦 API for Government App

<div align="left">
    <div style="display: inline-block;">
        <h2 style="display: inline-block; vertical-align: middle; margin-top: 0;">API FOR GOVERNMENT APP</h2>
        <p></p>
        <p>
        <img src="https://img.shields.io/github/last-commit/LevKosyk/ApiForGovermentApp?style=default&logo=git&logoColor=white&color=a0d1e2" alt="last-commit">
        <img src="https://img.shields.io/github/languages/top/LevKosyk/ApiForGovermentApp?style=default&color=a0d1e2" alt="repo-top-language">
        <img src="https://img.shields.io/github/languages/count/LevKosyk/ApiForGovermentApp?style=default&color=a0d1e2" alt="repo-language-count">
        </p>
    </div>
</div>

---

## 🌐 Language Switch | Зміна мови

* [🇺🇸 English](#-overview)
* [🇺🇦 Українська](#-огляд-для-користувачів)

---

## 📍 Overview

> API built for a React Native-based government app inspired by the movie "Law Abiding Citizen" ;)

---

## 📁 Project Structure

```sh
ApiForGovermentApp/
├── ApiForGovermentApp/
│   ├── Controllers/
│   ├── Data/
│   ├── Migrations/
│   ├── Models/
│   ├── Services/
│   ├── Properties/
│   ├── ApiForGovermentApp.csproj
│   ├── ApiForGovermentApp.http
│   ├── Program.cs
│   ├── appsettings.Development.json
│   └── appsettings.json
├── ApiForGovermentApp.sln
├── docker-compose.yml
├── Dockerfile
└── README.md
```

---

## 🚀 Getting Started

### ☑️ Prerequisites

* **Language:** C#
* **IDE:** Visual Studio / VS Code
* **Database:** SQL Server
* **DB Tool:** SQL Server Management Studio

### ⚙️ Installation (Local)

1. **Install SQL Server**: [Download SQL Server](https://www.microsoft.com/ru-ru/sql-server/sql-server-downloads)

   * 🎥 [Watch Installation Video](https://www.youtube.com/watch?v=RzB7An6nDgg)
2. **Install SSMS**: [Download SSMS](https://learn.microsoft.com/en-us/ssms/download-sql-server-management-studio-ssms)

   * 🎥 [SSMS Installation Guide](https://www.youtube.com/watch?v=7zXtA0LwoHs)
3. **Install Visual Studio**: [Download Visual Studio](https://visualstudio.microsoft.com)
4. **(Optional)** Install VS Code: [Download VS Code](https://code.visualstudio.com/)

### 📦 Setup Project

```sh
# Clone the repository
> git clone https://github.com/LevKosyk/ApiForGovermentApp

# Navigate to project directory
> cd ApiForGovermentApp

# Update `appsettings.json`
Replace `YOUR-SERVER-PATH` with your SQL Server instance path.

# Apply database migrations
> dotnet ef migrations add InitialCreate
> dotnet ef database update

# Run the application
> dotnet run
```

---

## 🐳 Docker Installation

### ⚙️ Prerequisites

* Docker Desktop installed: [Get Docker](https://www.docker.com/products/docker-desktop)

### 📄 Docker Setup

```sh
# Clone the project
> git clone https://github.com/LevKosyk/ApiForGovermentApp
> cd ApiForGovermentApp

# Build and run Docker containers
> docker-compose up --build
```

* This will start both the API and the local SQL Server instance using Docker Compose.
* Make sure your `docker-compose.yml` defines services for both `web` (the API) and `db` (SQL Server).
* Default SQL Server connection string is configured to:

  ```json
  "ConnectionStrings": {
   	"DefaultConnection": "Server=YOUR-SERVER-PATH;Database=APIDB;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
  ```
* You can customize environment variables in `docker-compose.yml` for database credentials.

🎥 Example video for Docker setup: [Docker Compose + SQL Server](https://www.youtube.com/watch?v=bzCn1jRgfGg)

---

## 🇺🇦 Огляд для користувачів (Ukrainian Guide)

### ☑️ Передумови

* **Мова програмування:** C#
* **Редактор коду:** Visual Studio або VS Code
* **База даних:** SQL Server
* **Інструмент БД:** SQL Server Management Studio

### ⚙️ Встановлення (локально)

1. Завантажте SQL Server: [SQL Server](https://www.microsoft.com/ru-ru/sql-server/sql-server-downloads)

   * 🎥 [Відео інструкція](https://www.youtube.com/watch?v=f9bsZrL8fdc)
2. Завантажте SSMS: [SQL Server Management Studio](https://learn.microsoft.com/en-us/ssms/download-sql-server-management-studio-ssms)

   * 🎥 [Інструкція по SSMS](https://www.youtube.com/watch?v=f9bsZrL8fdc)
3. Завантажте Visual Studio: [Visual Studio](https://visualstudio.microsoft.com)

### 🔧 Налаштування проєкту

```sh
# Клонування репозиторію
> git clone https://github.com/LevKosyk/ApiForGovermentApp

# Перейдіть у директорію
> cd ApiForGovermentApp

# Замініть `YOUR-SERVER-PATH` в appsettings.json на шлях до вашого SQL Server

# Застосуйте міграції
> dotnet ef migrations add InitialCreate
> dotnet ef database update

# Запустіть застосунок
> dotnet run
```

### 🐳 Встановлення через Docker

```sh
# Клонуйте репозиторій
> git clone https://github.com/LevKosyk/ApiForGovermentApp
> cd ApiForGovermentApp

# Запуск через Docker
> docker-compose up --build
```

* Ця команда запустить одночасно API і SQL Server (локально через Docker).
* Переконайтесь, що `docker-compose.yml` містить сервіс для `web` (API) та `db` (SQL Server).
* За замовчуванням, підключення до бази даних виглядає так:

  ```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=db;Database=GovernmentAppDb;User=sa;Password=Your_password123;"
  }
  ```
* Ви можете змінити налаштування в `docker-compose.yml` для облікових даних.

🎥 Відео по Docker + MSSQL: [Docker Compose та MSSQL](https://www.youtube.com/watch?v=bzCn1jRgfGg)

---

## 📞 Contact

If you have any questions, feel free to open an issue or contact [LevKosyk](https://github.com/LevKosyk) via GitHub.

---

> Made with ❤️ by a law-abiding citizen 😉
