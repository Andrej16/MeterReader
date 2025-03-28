# MeterReader

MeterReader is a Razor Pages project designed to manage and read meter data with gRPC services. It includes features such as token generation for authentication, customer data retrieval.

## Features

- **Token Generation**: Securely generate JWT tokens for authentication.
- **Customer Data Retrieval**: Fetch customer data along with their meter readings.
- **gRPC Services**: High-performance communication using gRPC.

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. Clone the repository:
2. Set up the database connection string in `appsettings.json`:
3. Apply database migrations:
4. Run the application:
### Configuration

- **Authentication**: Configure JWT authentication in `Program.cs`.
- **CORS**: Set up CORS policies in `Program.cs`.

### Usage

- **Token Generation**: 
    - Endpoint: `/api/token`
    - Method: `POST`
    - Body:
- **Get All Customers**:
    - Endpoint: `/api/customers`
    - Method: `GET`

- **Get Customer by ID**:
    - Endpoint: `/api/customers/{id}`
    - Method: `GET`

### gRPC Services

- **MeterReadingService**: Provides gRPC endpoints for meter reading operations.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License.
