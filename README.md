# Pokemon API Mini Project
### Overview
This project aims to create a scalable and well-organized API for managing Pokemon data. The API allows for the creation, retrieval, updating, and deletion of Pokemon records. The provided CSV file will be used to populate the database, and Swagger will be utilized for API documentation.

## Endpoints
### 1. POST /pokemon
- Description: Add a new Pokemon.
- Constraints: Ensure no duplicate names.
- Error Handling: Return an error if a duplicate name is detected.
### 2. GET /pokemon
- Description: Get a list of Pokemon with filtering and sorting.
- Parameters:
  - type (optional): Filter by Pokemon type.
  - sort (optional): Sort by name.
  - sortOrder (optional): Sort order, either asc (ascending) or desc (descending).
### 3. GET /pokemon/{pokemonId}
- Description: Get Pokemon details by ID.
### 4. PUT /pokemon/{pokemonId}
- Description: Update Pokemon details by ID and return the updated data.
### 5. DELETE /pokemon/{pokemonId}
- Description: Delete a Pokemon by ID.

## Project Requirements
### Setup
- Scalability: Ensure the API is scalable and well-organized.
- Database: Use SqlServer for the database, prepare the migration in a way that easy to launch the project
- Authentication: Not required.
### Data
- Database Table: Create a table named Pokemons with the following columns:
  - ID: Unique identifier.
  - Name: Name of the Pokemon.
  - Type: Type of the Pokemon.
  - Speed: Speed of the Pokemon.
  - Shiny: Boolean indicating if the Pokemon is shiny.
### CSV File
- File: pokemon_data.csv containing several hundred rows of Pokemon data.
- Usage: Use this file to populate the database.
### Swagger Specification
Documentation: Access the API documentation via Swagger UI at [http://localhost:7174/swagger](https://localhost:7174/swagger/index.html).
## Guidelines
- CSV File: Use the provided CSV file to populate your database.
- Swagger Specification: Follow the provided Swagger specification to implement the API endpoints.
- Code Quality: Ensure your code is clean, well-organized, and scalable.
## How to Run
- Clone this Repository
- Setup the Database:
  - Ensure your database is running and accessible.
  - Update the connection string in appsettings.json.
- Import CSV Data:
  - Use a script or tool to import the pokemon_data.csv into the Pokemons table in your database.
- Run the Application
