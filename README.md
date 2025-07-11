# Currency Exchange API

A robust REST API for currency exchange rates and conversions built with ASP.NET Core. This service provides real-time currency exchange functionality commonly used in fintech applications.

## 🚀 Features

- **Real-time Exchange Rates**: Get current exchange rates for major currencies
- **Currency Conversion**: Convert amounts between different currencies
- **Multiple Currency Support**: USD, EUR, GBP, JPY, CAD
- **RESTful API Design**: Clean, intuitive endpoints
- **Comprehensive Logging**: Built-in logging for monitoring and debugging
- **Swagger Documentation**: Interactive API documentation
- **Error Handling**: Proper HTTP status codes and error messages

## 🛠️ Technology Stack

- **.NET 9**: Latest .NET framework
- **ASP.NET Core**: Web API framework
- **Swagger/OpenAPI**: API documentation
- **JSON**: Data exchange format
- **CORS**: Cross-origin resource sharing support

## 📋 Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- IDE of choice (Visual Studio, VS Code, JetBrains Rider)

## 🔧 Installation & Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/CurrencyExchangeAPI.git
   cd CurrencyExchangeAPI
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Run the application**
   ```bash
   dotnet run
   ```

4. **Access the API**
   - API Base URL: `https://localhost:7xxx` (check console for exact port)
   - Swagger UI: `https://localhost:7xxx/swagger`

## 📖 API Documentation

### Get Exchange Rates

Retrieve exchange rates for a specific base currency.

```http
GET /api/ExchangeRate/rates/{baseCurrency}
```

**Parameters:**
- `baseCurrency` (string): The base currency code (e.g., USD, EUR, GBP)

**Example Request:**
```bash
curl -X GET "https://localhost:7xxx/api/ExchangeRate/rates/USD"
```

**Example Response:**
```json
{
  "baseCurrency": "USD",
  "rates": {
    "EUR": 0.85,
    "GBP": 0.75,
    "JPY": 110.0,
    "CAD": 1.25
  },
  "lastUpdated": "2024-07-11T10:30:00Z"
}
```

### Convert Currency

Convert an amount from one currency to another.

```http
POST /api/ExchangeRate/convert
```

**Request Body:**
```json
{
  "amount": 100,
  "fromCurrency": "USD",
  "toCurrency": "EUR"
}
```

**Example Request:**
```bash
curl -X POST "https://localhost:7xxx/api/ExchangeRate/convert" \
  -H "Content-Type: application/json" \
  -d '{
    "amount": 100,
    "fromCurrency": "USD",
    "toCurrency": "EUR"
  }'
```

**Example Response:**
```json
{
  "originalAmount": 100,
  "fromCurrency": "USD",
  "toCurrency": "EUR",
  "convertedAmount": 85.00,
  "exchangeRate": 0.85,
  "conversionDate": "2024-07-11T10:30:00Z"
}
```

## 🔍 Supported Currencies

| Currency | Code | Name |
|----------|------|------|
| US Dollar | USD | United States Dollar |
| Euro | EUR | Euro |
| British Pound | GBP | British Pound Sterling |
| Japanese Yen | JPY | Japanese Yen |
| Canadian Dollar | CAD | Canadian Dollar |

## 📊 HTTP Status Codes

| Code | Description |
|------|-------------|
| 200 | OK - Request successful |
| 400 | Bad Request - Invalid parameters |
| 404 | Not Found - Currency not supported |
| 500 | Internal Server Error - Server error |

## 🔧 Configuration

The API uses default configurations but can be customized through `appsettings.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## 🧪 Testing

### Manual Testing with Swagger

1. Run the application
2. Navigate to `https://localhost:7xxx/swagger`
3. Test endpoints directly from the browser

### Testing with cURL

**Get USD exchange rates:**
```bash
curl -X GET "https://localhost:7xxx/api/ExchangeRate/rates/USD"
```

**Convert 100 USD to EUR:**
```bash
curl -X POST "https://localhost:7xxx/api/ExchangeRate/convert" \
  -H "Content-Type: application/json" \
  -d '{"amount": 100, "fromCurrency": "USD", "toCurrency": "EUR"}'
```

## 🚀 Deployment

### Local Development
```bash
dotnet run --environment Development
```

### Production Build
```bash
dotnet publish -c Release -o ./publish
```

## 🔮 Future Enhancements

- [ ] Integration with real exchange rate APIs (e.g., ExchangeRate-API, Fixer.io)
- [ ] Rate limiting and API key authentication
- [ ] Historical exchange rate data
- [ ] Caching for improved performance
- [ ] Database integration for rate storage
- [ ] Unit and integration tests
- [ ] Docker containerization
- [ ] CI/CD pipeline setup

## 📝 API Design Principles

- **RESTful**: Follows REST architectural principles
- **Stateless**: No server-side session state
- **JSON-first**: All data exchange in JSON format
- **Error-friendly**: Consistent error response format
- **Documented**: Self-documenting with Swagger

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**Your Name**
- GitHub: [@yourusername](https://github.com/yourusername)
- LinkedIn: [Your LinkedIn](https://linkedin.com/in/yourprofile)

## 🔗 Related Projects

- [Transaction Validator](https://github.com/yourusername/TransactionValidator) - Fraud detection system
- [Payment Processing System](https://github.com/yourusername/PaymentProcessingSystem) - Complete payment gateway

---

⭐ If you found this project helpful, please give it a star!
