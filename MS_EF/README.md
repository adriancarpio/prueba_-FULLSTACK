# API Desarrollo - Form & Input CRUD
 
## 1. Requisitos
Para ejecutar el backend en un ambiente de desarrollo local, asegúrate de contar con los siguientes requisitos:
 
### Software necesario:
- .NET SDK 6.0 o superior
- Postgres SQL (local o en contenedor Docker)
- Visual Studio 2022 o Visual Studio Code
- Entity Framework Core
- Postman o herramienta similar para probar la API
 
### Dependencias del proyecto:
- ASP.NET Core Web API
- Entity Framework Core
- Npgsql.EntityFrameworkCore.PostgreSQL(6.0.29)
- Microsoft.EntityFrameworkCore.Tools
- Newtonsoft.Json
 
## 2. Ejecución del backend
Para ejecutar el backend en un ambiente de desarrollo local, sigue los siguientes pasos:
 
### 1. Clonar el repositorio
```sh
git clone https://github.com/tu-usuario/tu-repositorio.git
cd tu-repositorio
```
 
### 2. Configurar la base de datos
Asegúrate de que SQL Server esté corriendo y crea una base de datos si es necesario. Luego, configura la conexión en `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5433;Database=postgres;Username=postgres;Password=TuPassword"
}
```
 
### 3. Aplicar migraciones de Entity Framework
Ejecuta los siguientes comandos en la terminal dentro del proyecto:
```sh
dotnet ef database update
```
 
### 4. Ejecutar el backend
Para correr la API, usa el siguiente comando:
```sh
dotnet run
```
También puedes ejecutarlo desde Visual Studio presionando `F5`.
 
### 5. Probar la API
Una vez que la API esté corriendo, puedes probar los endpoints usando Postman o el navegador en:
```sh
http://localhost:5250
```
