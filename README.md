# Menu Management System

The **Menu Management System** is a .NET Core web application designed for restaurant or catering services to manage dishes and their ingredients. This project provides a user-friendly interface to view, create, and manage dishes, complete with images, prices, and detailed ingredient lists.

## Features

- **Dish Management**: 
  - Add, update, and delete dishes with attributes like name, price, and image.
  
- **Ingredient Management**: 
  - Manage ingredients and associate them with specific dishes.
  
- **Dish-Ingredient Relationships**: 
  - Establish many-to-many relationships between dishes and ingredients.
  
- **Data Seeding**: 
  - Pre-populated with popular Nigerian dishes and their ingredients.
  
- **Responsive UI**: 
  - A clean and responsive user interface for easy navigation and management.

## Technologies Used

- **.NET Core 6**
- **Entity Framework Core**
- **ASP.NET MVC**
- **SQL Server**
- **Bootstrap 5**

## Getting Started

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

### Installation

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/your-username/menu-management-system.git
   cd menu-management-system
   ```

2. **Setup Database:**

   - Update the connection string in `appsettings.json` to point to your SQL Server instance.
   - Run migrations to create the database:

   ```bash
   dotnet ef database update
   ```

3. **Run the Application:**

   ```bash
   dotnet run
   ```

   or launch the project using Visual Studio.

### Usage

- Navigate to the homepage to view all dishes.
- Click on a dish to view details, including the ingredients.
- Use the provided forms to add or update dishes and ingredients.

## Project Structure

- `Menu.Models` - Contains the domain models like `Dish`, `Ingredient`, and `DishIngredient`.
- `Menu.Data` - Contains the `DbContext` and seed data.
- `Menu.Controllers` - Handles the HTTP requests and business logic.
- `Menu.Views` - Contains the Razor views for the UI.

## Sample Data

The project is seeded with sample Nigerian dishes:

- **Jollof Rice**
- **Egusi Soup**
- **Suya**
- **Moi Moi**
- **Pounded Yam and Egusi Soup**

