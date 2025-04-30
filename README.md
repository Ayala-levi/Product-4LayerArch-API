# Product 4-Layer Architecture Project

This project demonstrates a modern 4-layer architecture for managing product table information. The project separates the different concerns of the application into distinct modules, which simplifies maintenance, expansion, and testing.

## Architecture

The project is built on a 4-layer architecture:

1.  **Core:** This layer contains the business entities and the definitions of the interfaces. It forms the foundation of the application and is independent of other layers. The goal is to reduce dependencies between layers and share information throughout the application.
2.  **Data:** This layer is responsible for data access. It contains the DataContext (the database connection) and the implementation of the Repositories. This layer is separated from the other layers to allow easy replacement of the database technology.
3.  **Service:** This layer contains the business logic of the application. It uses the Repositories to access data and provides a uniform interface to the API layer.
4.  **API:** This layer is responsible for exposing the application to the external world through APIs. It receives HTTP requests, processes them using the Services, and returns responses.

## Technologies Used

* .NET
* Entity Framework Core (EF Core): ORM for convenient database access.
* Dependency Injection (DI): For managing dependencies between the various components in the application.
* SQL Server: The database used.
* C#

## Explanation of the Layers

### Core Layer

This layer defines the "contracts" of the application. It contains:

* **Entities:** Classes representing the database tables (e.g., `Product`).
* **Repositories Interfaces:** Define the data access operations (CRUD) for each entity (e.g., `IProductRepository`).
* **Services Interfaces:** Define the business operations that the application performs (e.g., `IProductService`).

### Data Layer

This layer implements the interfaces defined in the Core layer.

* **DataContext:** A class representing the connection to the database using EF Core.
* **Repositories:** Classes that implement the Repository interfaces and contain the logic for data access (e.g., `ProductRepository`).

To install the necessary libraries:

* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.SqlServer
* Microsoft.EntityFrameworkCore.Tools

Also, perform migrations using the following commands:

* Add-migration "migration name"
* Update-database

### Service Layer

This layer implements the interfaces defined in the Core layer and contains the business logic of the application. It uses Repositories from the Data layer to access data.

### API Layer

This layer exposes the functionality of the application through APIs.

* **Controllers:** Classes that handle HTTP requests and return responses. They use services from the Service layer to perform the business operations.
* **Program.cs:** This file defines the application's services (including dependency injection) and the HTTP pipeline.
* **appsettings.json:** This file contains various application settings, including the database connection string.

## Dependency Injection (DI)

The project uses Dependency Injection to manage dependencies between the layers. Dependency injection is configured in the `Program.cs` file using the `ServiceCollection`.

* **AddScoped:** Creates a new instance of the service for each HTTP request.

## Entity Framework Core

The project uses EF Core for database access.

* **DataContext:** Represents the connection to the database and enables CRUD operations on the entities.
* **Migrations:** Allow managing database schema changes.
* **Include:** Allows loading related data from other tables.
* **IgnoreCycles:** Resolves issues with circular relationships between entities.

## Running the Application

1.  Ensure that the .NET SDK is installed.
2.  Configure the database connection string in the `appsettings.json` file.
3.  Use the Package Manager Console to run migrations:
    * `Add-Migration "InitialCreate"`
    * `Update-Database`
4.  Run the API project.
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
# פרויקט ארכיטקטורת 4 שכבות - מוצרים

פרויקט זה מדגים ארכיטקטורת 4 שכבות מודרנית עבור ניהול מידע של טבלת "מוצרים". הפרויקט מפריד את הדאגות השונות של האפליקציה למודולים נפרדים, מה שמקל על תחזוקה, הרחבה ובדיקה.

## ארכיטקטורה

הפרויקט בנוי בארכיטקטורת 4 שכבות:

1.  **Core (ליבה):** שכבה זו מכילה את הישויות העסקיות ואת ההגדרות של הממשקים. היא מהווה את הבסיס של האפליקציה ואינה תלויה בשכבות אחרות. המטרה היא להפחית תלויות בין השכבות ולשתף מידע בכל האפליקציה.
2.  **Data (מידע):** שכבה זו אחראית על הגישה לנתונים. היא מכילה את ה-DataContext (הקשר למסד הנתונים) ואת המימוש של ה-Repositories. שכבה זו מופרדת משאר השכבות כדי לאפשר החלפה קלה של טכנולוגיית מסד הנתונים.
3.  **Service (שירות):** שכבה זו מכילה את הלוגיקה העסקית של האפליקציה. היא משתמשת ב-Repositories כדי לגשת לנתונים ומספקת ממשק אחיד לשכבת ה-API.
4.  **API (ממשק):** שכבה זו אחראית על חשיפת האפליקציה לעולם החיצון באמצעות ממשקי API. היא מקבלת בקשות HTTP, מעבדת אותן באמצעות ה-Services ומחזירה תגובות.

## טכנולוגיות בשימוש

* .NET
* Entity Framework Core (EF Core): ORM לגישה נוחה למסד הנתונים.
* Dependency Injection (DI): לניהול תלויות בין הקומפוננטות השונות באפליקציה.
* SQL Server: מסד הנתונים בו נעשה שימוש.
* C#

## הסבר על השכבות

### שכבת ה-Core

שכבה זו מגדירה את ה"חוזים" של האפליקציה. היא מכילה:

* **Entities (ישויות):** מחלקות המייצגות את טבלאות מסד הנתונים (למשל, `Product`). 
* **Repositories Interfaces (ממשקי ריפוזיטורי):** מגדירים את הפעולות לגישה לנתונים (CRUD) עבור כל ישות (למשל, `IProductRepository`).
* **Services Interfaces (ממשקי שירות):** מגדירים את הפעולות העסקיות שהאפליקציה מבצעת (למשל, `IProductService`). 
  
### שכבת ה-Data

שכבה זו מממשת את הממשקים שהוגדרו בשכבת ה-Core.

* **DataContext:** מחלקה המייצגת את החיבור למסד הנתונים באמצעות EF Core. 
* **Repositories:** מחלוקות המממשות את ממשקי ה-Repository ומכילות את הלוגיקה לגישה לנתונים (למשל, `ProductRepository`).

יש להתקין את הספריות הבאות:
* Microsoft.EntityFrameworkCore.Design
* Microsoft.EntityFrameworkCore.SqlServer
* Microsoft.EntityFrameworkCore.Tools

כמו כן, יש לבצע מיגרציות באמצעות הפקודות הבאות:
* Add-migration  "migration name"
* Update-database
### שכבת ה-Service

שכבה זו מממשת את הממשקים שהוגדרו בשכבת ה-Core ומכילה את הלוגיקה העסקית של האפליקציה. היא משתמשת ב-Repositories משכבת ה-Data כדי לגשת לנתונים.
### שכבת ה-API

שכבה זו חושפת את הפונקציונליות של האפליקציה באמצעות ממשקי API.

* **Controllers:** מחלוקות המטפלות בבקשות HTTP ומחזירות תגובות. הם משתמשים בשירותים משכבת ה-Service כדי לבצע את הפעולות העסקיות.
* **Program.cs:** קובץ זה מגדיר את השירותים של האפליקציה (כולל הזרקת תלויות) ואת ה-pipeline של ה-HTTP.
* **appsettings.json:** קובץ זה מכיל הגדרות שונות של האפליקציה, כולל מחרוזת החיבור למסד הנתונים.
## Dependency Injection (הזרקת תלויות)

הפרויקט משתמש ב-Dependency Injection כדי לנהל את התלויות בין השכבות. הזרקת התלויות מוגדרת בקובץ `Program.cs` באמצעות ה-`ServiceCollection`.

* **AddScoped:** יוצר מופע חדש של השירות עבור כל בקשת HTTP. 

## Entity Framework Core

הפרויקט משתמש ב-EF Core לגישה למסד הנתונים. 

* **DataContext:** מייצג את החיבור למסד הנתונים ומאפשר לבצע פעולות CRUD על הישויות. 
* **Migrations:** מאפשרות לנהל את שינויי הסכמה של מסד הנתונים. 
* **Include:** מאפשר לטעון נתונים קשורים מטבלאות אחרות. 
* **IgnoreCycles:** פותר בעיות של קשרים מעגליים בין ישויות. 

## הרצה

1.  ודא שמותקן אצלכם .NET SDK.
2.  הגדר את מחרוזת החיבור למסד הנתונים בקובץ `appsettings.json`.
3.  השתמש ב-Package Manager Console כדי להריץ מיגרציות:
* `Add-Migration "InitialCreate"`
* `Update-Database`
4.  הרץ את פרויקט ה-API.

