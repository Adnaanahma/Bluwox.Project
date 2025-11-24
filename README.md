# Service Management API

A robust RESTful API built with ASP.NET Core for managing business services, categories, and subcategories. This system handles service creation, fare management, categorization, and advanced filtering.

## 🚀 Technologies Used
* **Framework:**  .NET 8 (ASP.NET Core Web API)
* **Database:** SQL Server
* **ORM:** Entity Framework Core
* **Documentation:** Swagger / OpenAPI

## ⚙️ Getting Started

1.  **Clone the repository**
2.  **Configure Database:**
    Update the `DefaultConnection` string in `appsettings.json` to point to your SQL Server instance.
3.  **Run Migrations:**
    ```bash
    dotnet ef database update
    ```
4.  **Run the Application:**
    ```bash
    dotnet run
    ```
    The API will launch on `https://localhost:7160` (or your configured port).

## 📡 API Endpoints

The API is versioned. The base URL structure is: `/api/v{version}/[Controller]`.
*Default version: v1*

### 📂 Category Management

| Method | Endpoint | Description |
| :--- | :--- | :--- |
| **POST** | `/api/v1/Category/add` | Create a new Category |
| **GET** | `/api/v1/Category/get-all` | Retrieve a list of all Categories and their SubCategories |

### 📂 SubCategory Management

| Method | Endpoint | Description |
| :--- | :--- | :--- |
| **POST** | `/api/v1/SubCategory/add` | Add a new SubCategory under an existing Category |

### 🚕 Service Management

| Method | Endpoint | Description |
| :--- | :--- | :--- |
| **POST** | `/api/v1/ServiceManagement/add` | Create a new Business Service |
| **POST** | `/api/v1/ServiceManagement/get-all` | Retrieve all services (Supports complex body parameters) |
| **PUT** | `/api/v1/ServiceManagement/update` | Update an existing service (Name, Category, Fare) |
| **PUT** | `/api/v1/ServiceManagement/status-update` | Toggle the Active/Inactive status of a service |
| **DELETE**| `/api/v1/ServiceManagement/delete` | Remove a service from the system |
| **PUT** | `/api/v1/ServiceManagement/filter` | Advanced search by Name, Category, Date Range, etc. |

---

## 📝 Example JSON Payloads

### Create Service
**POST** `/api/v1/ServiceManagement/add`
```json
{
  "serviceName": "Executive Taxi",
  "category": "Transport",
  "baseFare": 5000
}
