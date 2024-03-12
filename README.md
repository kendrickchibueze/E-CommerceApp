# E-Commerce API System 🛒💸 💸
 ![](https://github.com/kendrickchibueze/E-CommerceApp/blob/master/Screenshot%20(641).png?raw=true)
 ![](https://github.com/kendrickchibueze/E-CommerceApp/blob/master/Screenshot%20(642).png?raw=true)

The Ecommerce API  System is  developed using ASP.NET Core and angular frontend to efficiently organize, track, and manage shopping of products by users. Seamlessly handle authentication, Add product to cart, order products. Enhance productivity and streamline workflows effortlessly.

## Deliverables
Implemented clean software architectures(with the core and infrastructure class libraries) 😅
* seed products with Types and Brands
* Authenticate Users
* See all Products
* Filter products  by Types and Brands
* Add Products to cart (implemented with redis server)
* Paginate Products
* Order Products

## Background services
* Custom error handling
* Authentication and Authorization: Secure access to API endpoints with user authentication and role-based authorization.
* Validation: Input data validation to ensure data integrity.
* Documentation: API documentation for easy integration using Swagger.

## Technology
ASP.NET Core 6.0,
Entity Framework Core 6.0.22

### Prerequisites
.NET 6 SDK
Visual Studio
Getting Started
Follow these steps to set up and run the API locally:

**__Clone this repository_**:

```dotnetcli
 git clone https://github.com/kendrickchibueze/E-CommerceApp.git
 cd E-commerceApp
```


Provide database connection string in appsettings.json or Leave as is to user in-app database
Apply database migrations to create the database:
Packager Manager : Update-Database
Build and run the API:
dotnet run
The API should be accessible at http://localhost:5001 (or https://localhost:7016 for HTTPS).

## API Endpoints 🔚
For detailed information about available API endpoints and their usage, refer to the API Documentation section or navigate to /swagger when the API is running locally.

## Authentication
To access protected endpoints, you must obtain an authentication token. Refer to the API documentation for authentication details.

##  Swagger Documentation
API documentation can be found at /swagger when the API is running locally. For additional documentation and usage examples, please refer to API Documentation.

## Security
This project follows security best practices to protect against common vulnerabilities. Regularly update dependencies to address security concerns.

## Authors
👤 kendrick chukwuka

* GitHub: @kendrickchibueze
* Twitter: @kendrickchukwu2
* LinkedIn: kendrick chukwuka
* Contributing: Contributions are welcome!

License
This project is licensed under the MIT License.
