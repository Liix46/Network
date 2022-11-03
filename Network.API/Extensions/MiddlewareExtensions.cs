using Network.API.Middlewares;

namespace Network.API.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app) =>
        app.UseMiddleware<ExceptionHandlingMiddleware>();

    public static IApplicationBuilder UseDbTransction(this IApplicationBuilder app) =>
        app.UseMiddleware<DbTransactionMiddleware>();

}