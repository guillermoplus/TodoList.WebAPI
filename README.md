# TodoList Web API

Esta es una solución para una API web de lista de tareas (TodoList) desarrollada en C# utilizando ASP.NET Core. La API permite gestionar tareas mediante operaciones CRUD (Crear, Leer, Actualizar, Eliminar) y marcar tareas como completadas. La autenticación se realiza mediante JWT (JSON Web Tokens).

## Requisitos

- .NET 8.0 o superior
- Visual Studio 2022 o JetBrains Rider
- SQLite

## Configuración

1. Clona el repositorio:
    ```sh
    git clone https://github.com/guillermoplus/TodoList.WebAPI.git
    cd TodoList.WebAPI
    ```

2. Configura las variables de entorno en `appsettings.json`:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Data Source=todolist.db"
      },
      "JwtSettings": {
        "Secret": "tu-secreto",
        "Issuer": "tu-issuer",
        "Audience": "tu-audience",
        "ExpiresInMinutes": "60"
      }
    }
    ```

## Ejecución

1. Restaura los paquetes NuGet:
    ```sh
    dotnet restore
    ```

2. Aplica las migraciones de la base de datos:
    ```sh
    dotnet ef database update
    ```

3. Ejecuta la aplicación:
    ```sh
    dotnet run --project TodoList.WebAPI
    ```

## Endpoints

### Autenticación

- **POST /api/auth/login**: Autentica un usuario y devuelve un token JWT.

### Tareas

- **GET /api/todotask/{id}**: Obtiene una tarea por su ID.
- **GET /api/todotask/all**: Obtiene todas las tareas.
- **POST /api/todotask**: Crea una nueva tarea.
- **PUT /api/todotask/{id}**: Actualiza una tarea existente.
- **DELETE /api/todotask/{id}**: Elimina una tarea por su ID.
- **PATCH /api/todotask/{id}/complete**: Marca una tarea como completada.

## Seguridad

La API utiliza JWT para la autenticación. Asegúrate de incluir el token en el encabezado de autorización de tus solicitudes:

```http
Authorization
Bearer tu-token
```

## Documentación

La API incluye documentación Swagger. Para acceder a ella, ejecuta la aplicación y navega a `https://localhost:5240/swagger`.
