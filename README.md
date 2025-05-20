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

- [🇺🇸 English](#-overview)
- [🇺🇦 Українська](#-огляд-для-користувачів-ukrainian-guide)

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

# 📦 Setup Project


### 1.Clone the repository
```sh
git clone https://github.com/LevKosyk/ApiForGovermentApp
```
### 2. Navigate to project directory
```sh
cd ApiForGovermentApp
```
### 3. Update `appsettings.json`
```sh

Replace `YOUR-SERVER-PATH` with your SQL Server instance path.
```
### 4. Apply database migrations
```sh
dotnet ef migrations add InitialCreate
```
```sh
dotnet ef database update
```
### 5. Run the application
```sh
dotnet run
```
---

## 🐳Run with Docker (Option 2)

## ⚙️ Prerequisites

* Docker Desktop installed: [Get Docker](https://www.docker.com/products/docker-desktop)

## 📄 Docker Setup

### 1. Clone the project
```sh
git clone https://github.com/LevKosyk/ApiForGovermentApp
```
```sh
cd ApiForGovermentApp
```

### 2.  Build and run Docker containers

* You can customize environment variables in `docker-compose.yml` for database credentials.

```sh
docker-compose up --build
```

🎥 Example video for Docker setup: [Docker Compose + SQL Server](https://www.youtube.com/watch?v=ocMwNAt3-G0)

---

# 🇺🇦 Огляд для користувачів (Ukrainian Guide)

### ☑️ Передумови

* **Мова програмування:** C#
* **Редактор коду:** Visual Studio або VS Code
* **База даних:** SQL Server
* **Інструмент БД:** SQL Server Management Studio

## ⚙️ Встановлення (локально)

1. Завантажте SQL Server: [SQL Server](https://www.microsoft.com/ru-ru/sql-server/sql-server-downloads)

   * 🎥 [Відео інструкція](https://www.youtube.com/watch?v=f9bsZrL8fdc)
2. Завантажте SSMS: [SQL Server Management Studio](https://learn.microsoft.com/en-us/ssms/download-sql-server-management-studio-ssms)

   * 🎥 [Інструкція по SSMS](https://www.youtube.com/watch?v=f9bsZrL8fdc)
3. Завантажте Visual Studio: [Visual Studio](https://visualstudio.microsoft.com)

### 1. Клонування репозиторію
```sh
git clone https://github.com/LevKosyk/ApiForGovermentApp
```

### 2. Перехід у директорію проєкту
```sh
cd ApiForGovermentApp
```
### 3. 🔧 Оновіть appsettings.json
```sh
   "ConnectionStrings": {
  "DefaultConnection": "Server=YOUR-SERVER-PATH;Database=YourDbName;Trusted_Connection=True;"
}

```
#### Замініть YOUR-SERVER-PATH на шлях до вашого SQL Server.

### 4. Застосуйте міграції
```sh
dotnet ef migrations add InitialCreate
```
```sh
dotnet ef database update
```

### 5. Запустіть застосунок
```sh
dotnet run
```
## 🐳 Запуск через Docker
### ⚙️ Необхідне
Встановлений Docker Desktop
###🔗 Завантажити Docker

##📄 Налаштування Docker
### 1. Клонуйте репозиторій
```sh
git clone https://github.com/LevKosyk/ApiForGovermentApp
```

```sh
cd ApiForGovermentApp
```

### 2. Запустіть контейнер
```sh
docker-compose up --build
```
#### ⚙️ Ви можете змінити змінні середовища у docker-compose.yml для налаштування БД.

## 📞 Contact

If you have any questions, feel free to open an issue or contact [LevKosyk](https://github.com/LevKosyk) via GitHub.

---

> Made with ❤️ by a law-abiding citizen 😉
