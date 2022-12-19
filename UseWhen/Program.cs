var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.UseWhen(
    context => context.Request.Query.ContainsKey("username"),      //if this condition is true then app (lambda expression) is executed
    async app =>                                                         //if context condition is true then this app (lambda expression) is executed
    {                                                                     // in localhost give username for condition true
        app.Use(async (context, next) =>
        {
            await context.Response.WriteAsync("Hello from " +
                "middleware branch");
            await next();
        });
    });

app.Run(async context =>              //if context condition is false then this run method is executed
{
    await context.Response.WriteAsync("Hello from " +
                "middleware at main chain");
});
app.MapGet("/", () => "Hello World!");

app.Run();
