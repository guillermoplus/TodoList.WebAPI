using Microsoft.AspNetCore.Diagnostics;

namespace TodoList.WebAPI.Middlewares;

public static class GlobalExceptionHandler
{
    public static void ConfigureGlobalExceptionHandler(this IApplicationBuilder app)
    {
        // Excepciones de autenticación y autorización
        app.Use(async (context, next) =>
        {
            try
            {
                await next();
            }
            catch (UnauthorizedAccessException ex)
            {
                await HandleAuthExceptionAsync(context, ex, StatusCodes.Status401Unauthorized, "Acceso no autorizado");
            }
            catch (Exception ex)
            {
                await HandleAuthExceptionAsync(context, ex, StatusCodes.Status403Forbidden, "Acceso prohibido");
            }
        });

        // Excepciones generales
        app.UseExceptionHandler(exceptionHandlerApp =>
        {
            exceptionHandlerApp.Run(async context =>
            {
                context.Response.ContentType = "application/json";

                var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
                var statusCode = exception switch
                {
                    KeyNotFoundException => StatusCodes.Status404NotFound,
                    ArgumentException => StatusCodes.Status400BadRequest,
                    NotImplementedException => StatusCodes.Status501NotImplemented,
                    UnauthorizedAccessException => StatusCodes.Status401Unauthorized,
                    InvalidOperationException => StatusCodes.Status409Conflict,
                    _ => StatusCodes.Status500InternalServerError
                };

                context.Response.StatusCode = statusCode;

                var errorResponse = new
                {
                    success = false,
                    error = exception?.Message,
                    details = exception?.InnerException?.Message,
                    message = exception switch
                    {
                        KeyNotFoundException => "Recurso no encontrado",
                        ArgumentException => "Argumento inválido",
                        NotImplementedException => "Funcionalidad no implementada",
                        UnauthorizedAccessException => "Acceso no autorizado",
                        InvalidOperationException => "Operación inválida",
                        _ => "Error interno del servidor"
                    }
                };

                await context.Response.WriteAsJsonAsync(errorResponse);
            });
        });
    }

    private static Task HandleAuthExceptionAsync(HttpContext context, Exception exception, int statusCode, string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var errorResponse = new
        {
            success = false,
            error = exception.Message,
            message
        };

        return context.Response.WriteAsJsonAsync(errorResponse);
    }
}
