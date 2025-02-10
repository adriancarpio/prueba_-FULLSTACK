# Evaluación Técnica Fullstack .NET y Angular

Este proyecto es una aplicación web que permite la carga dinámica de formularios.

## Estructura del Proyecto

- `MS_EF/`: Contiene el backend desarrollado en .NET 6.
- `front-end/`: Contiene el frontend desarrollado en Angular.
- `script.sql`: Contiene los scripts de la base de datos.

## Requisitos

- Docker y Docker Compose instalados en el sistema.
- Node.js y Angular CLI para desarrollo frontend.
- .NET 6 SDK para desarrollo backend.

## Despliegue con Docker

Para ejecutar el proyecto utilizando Docker, sigue los siguientes pasos:

1. Clonar el repositorio:
   ```sh
   git clone (https://github.com/adriancarpio/prueba_-FULLSTACK.git)
   ```

2. Construir y ejecutar los contenedores:
   ```sh
   docker-compose up --build
   ```

3. Acceder a la aplicación:
   - Backend: [http://localhost:5250](http://localhost:5000)
   - Frontend: [http://localhost:4200](http://localhost:4200)

## Desarrollo y Pruebas

### Backend

Para ejecutar el backend en un entorno local:
```sh
cd MS_EF
 dotnet run
```

### Frontend

Para ejecutar el frontend en un entorno local:
```sh
cd front-end
npm install
ng serve --open
```

## Base de Datos

Se utiliza Postgres SQL como base de datos. Para ejecutarlo sin Docker, asegúrate de tener Postgres SQL instalado y ejecutar el script `script.sql` en tu gestor de base de datos.

---
