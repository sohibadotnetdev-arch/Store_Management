# Store_Management
A complete Store Management System built with ASP.NET Core, designed to manage Categories, Products, Users, Authentication, Sales, and Sale Items.
 Features
 Authentication

User Registration

User Login

Refresh Token

Logout

Category Management

Create Category

Update Category

Delete Category

Get All Categories

Get Category by ID

 Product Management

Create Product

Update Product

Delete Product

Get All Products

Get Product by ID

 User Management

Get All Users

Manage user information

Sales & Sale Items

Create Sale

Add Sale Items

Calculate Total Amount



Technologies Used

C#

ASP.NET Core Web API

Entity Framework Core

SQL Server

JWT Authentication

Dependency Injection

⚙️ How to Run the Project
1. Clone the repository
git clone https://github.com/USERNAME/Store_Management.git

2. Restore dependencies
dotnet restore

3. Update database
dotnet ef database update

4. Run the API
dotnet run

📡 Main API Endpoints
Auth
Method	Endpoint	Description
POST	/api/auth/register	Register a new user
POST	/api/auth/login	Login
POST	/api/auth/refresh	Refresh access token
POST	/api/auth/logout	Logout
Category
Method	Endpoint	Description
POST	/api/category	Create category
GET	/api/category	Get all categories
GET	/api/category/{id}	Get category by ID
PUT	/api/category/{id}	Update category
DELETE	/api/category/{id}	Delete category
Product

(Similar CRUD actions as Category)

🧪 Testing

You can test the API via:

Swagger UI

Postman

🤝 Contributing

Contributions, issues, and feature requests are welcome!
Feel free to submit a pull request.

📝 License

This project is open-source and free to use.
