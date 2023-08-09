namespace FBAngularTW.ShortUrlLib.Middleware;

public class UseShortUrlMiddleware
{
    private readonly RequestDelegate _next;

    public UseShortUrlMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task InvokeAsync(HttpContext context, ShortUrlService shortUrlService)
    {
        var url = shortUrlService.GetUrl(context.Request.Host.Host);
        context.Response.Redirect(url);
        return Task.CompletedTask;
    }
}