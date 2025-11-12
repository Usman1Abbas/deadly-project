# deadly project

## Tech Stack

*   .NET 7 (C#)
*   React (JavaScript)
*   PostgreSQL
*   Docker

## Quick Start

1.  Clone the repository.
2.  Run `scripts/setup.sh` to install dependencies.
3.  Configure the `.env.example` file and rename it to `.env`.
4.  Run `docker-compose up --build` to start the application.

## Features

*   Product Management (CRUD operations)
*   Basic API for product data
*   React-based frontend

## Architecture

*   **API:** .NET 7 API with Controllers, Services, and Models.
*   **Client:** React frontend for user interaction.
*   **Database:** PostgreSQL database.

## Usage

1.  Access the API at `https://localhost:5000/products`.
2.  Access the frontend at `http://localhost:3000`.

## Roadmap

*   Implement user authentication.
*   Add more features to the ERP system (e.g., inventory management, order processing).
*   Improve the frontend UI/UX.
*   Add comprehensive unit and integration tests.