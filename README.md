# Cosmos DB Todo List App

A simple **.NET console application** that demonstrates how to use **Azure Cosmos DB for NoSQL** with the **Azure SDK for .NET**.  
This project shows basic CRUD operations (Create, Read, Update, Delete) using a Todo List example.

---

## 🚀 Features
- Connect to Azure Cosmos DB using the SDK
- Create a database and container if they don’t exist
- Perform CRUD operations on Todo items
- Simple, beginner-friendly code structure

---

## 📂 Project Structure
CosmosTodoApp/
├── Program.cs        # Main entry point
├── TodoItem.cs       # Model class
├── README.md         # Documentation
└── .gitignore


---

## ⚙️ Prerequisites
- [.NET 6+](https://dotnet.microsoft.com/download)
- An [Azure Cosmos DB account](https://learn.microsoft.com/azure/cosmos-db/introduction)
- Connection string from your Cosmos DB account

---

## 🔧 Setup & Run
1. Clone this repository:
   ```bash
   git clone https://github.com/mgabaloch/CosmosTodoApp.git
   cd CosmosTodoApp


2. Add the Cosmos DB SDK:
   ```bash
   dotnet add package Microsoft.Azure.Cosmos


3. Update the connection string in Program.cs:
   ```Csharp
   string connectionString = "<your-cosmos-connection-string>";


4. Run the app:
   ```bash
   dotnet run

## 📖 Example Output
Fetched: Learn Cosmos DB, Completed: False



## 🛠 Future Improvements
- Add a Web API layer (ASP.NET Core)
- Build a Blazor or React front-end
- Implement partitioning strategies
- Add unit tests

📚 Resources
Azure Cosmos DB Documentation (learn.microsoft.com in Bing)

Azure SDK for .NET

Microsoft Learn Path: Design and Develop with Cosmos DB (learn.microsoft.com in Bing)
