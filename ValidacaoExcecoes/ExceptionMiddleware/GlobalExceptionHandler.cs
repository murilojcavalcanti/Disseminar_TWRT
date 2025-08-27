using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using ValidacaoExcecoes.WebApp.CustomExceptions;

namespace ValidacaoExcecoes.WebApp.ExceptionMiddleware
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }catch(UserNotFoundException ex)
            {
                context.Response.StatusCode = (int)StatusCodes.Status404NotFound;
                context.Response.Redirect("/Home/Error");
                //await context.Response.WriteAsJsonAsync(new { error = ex.Message} );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"ocorreu uma exceção não tratada: {ex.Message}");
                context.Response.ContentType="application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var response = new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "ocorreu um erro interno no servidor. Por favor, tente novamnete mais tarde."
                };
                context.Response.Redirect("/Home/Error");
                //await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }

        }
    }
}
