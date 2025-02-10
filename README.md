# Evaluación Técnica Fullstack .NET y Angular

Este proyecto es una aplicación web que permite la carga dinámica de formularios.

## Estructura del Proyecto

- `MS_EF/`: Contiene el backend desarrollado en .NET 6.
- `front-end/`: Contiene el frontend desarrollado en Angular.
- `script.sql`: Contiene los scripts de la base de datos.

## Requisitos

- Node.js y Angular CLI para desarrollo frontend.
- .NET 6 SDK para desarrollo backend.

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
npm i
ng s -o
```

## Base de Datos

Se utiliza Postgres SQL como base de datos. Para ejecutarlo sin Docker, asegúrate de tener Postgres SQL instalado y ejecutar el script `script.sql` en tu gestor de base de datos.

---
