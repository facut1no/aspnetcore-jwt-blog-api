# PostCommentAPI

**Proyecto en desarrollo** - API RESTful en proceso de creación en C# para gestionar publicaciones y comentarios. Actualmente no está completamente funcional.

## Características (Planeadas)

- CRUD de publicaciones (posts)
- CRUD de comentarios por publicación
- Registro y Autenticacion de Usuarios usando JWT
- Arquitectura basada en ASP.NET Core
- Uso de Entity Framework para persistencia de datos

## Instalación

1. Clona el repositorio.
2. Restaura los paquetes NuGet:  
  ```
  dotnet restore
  ```
3. Ejecuta las migraciones y la API:  
  ```
  dotnet ef migrations add
  dotnet ef database update
  dotnet run
  ```

## Estado del Proyecto

Este proyecto está en fase de desarrollo. Los endpoints y funcionalidades pueden no estar completamente implementados o probados.
