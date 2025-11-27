# 🌟 Genshin Character Catalog: Core Business Logic Layer (Practical 14)

This repository contains the implementation of the **Core Business Logic Layer (CORE)** for the Genshin Impact character catalog as part of Practical Assignment No. 14

---

## 🎯 Project Goal and Architecture

The main objective is to demonstrate a **three-tier architecture** and the strict separation of concerns:

1.  **CORE (Business Logic):** Encapsulates all data processing and business rules (the focus of this assignment).
2.  **DATA (Persistence):** Abstracted from CORE using the `ICharacterRepository` interface.
3.  **PRESENTATION (CLI):** Responsible solely for calling the CORE service and displaying the final result.

### Key Architectural Principle
The **Dependency Inversion Principle (DIP)** is applied: The `CharacterService` depends on the abstraction (`ICharacterRepository`), ensuring it is loosely coupled and independent of the actual data source (`MockCharacterRepository`).

---

## 🛡 Implemented Business Rules (CharacterService)

The `CharacterService` class performs the following rules on the raw data (`CharacterDto`) to produce the clean Domain Model (`Character`):

1.  **Rarity Filtering:** Characters with a rarity of less than 4 stars are ignored (e.g., the mock character 'Sayu' is filtered out).
2.  **Text Processing (Truncation):** The `Description` field is trimmed to 50 characters if it is too long, and "..." is appended.
3.  **Mapping and Naming:** Fields like `Vision` and `Weapon` are mapped to the cleaner domain names: `Element` and `WeaponType`.
4.  **URL Generation:** A complete, valid image URL (`ImageUrl`) is constructed for display.

---

## 🚀 How to Run the Project

The project requires the **.NET 8 SDK** (or newer) to run.

1.  **Clone the Repository:**
    ```bash
    git clone [https://github.com/Doffliz/Genshin-Core-Layer.git](https://github.com/Dofflix/Genshin-Core-Layer.git)
    cd Genshin-Core-Layer
    ```
2.  **Execute the Application:**
    Run the following command from the project root directory (`/Core`):
    ```bash
    dotnet run
    ```
### Expected Output
The program will display the processed data (4 characters) and confirm the successful filtering and description truncation.
