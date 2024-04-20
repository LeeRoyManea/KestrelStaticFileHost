var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllers();

var app = builder.Build();


app.UseCors(policyBuilder => policyBuilder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapFallbackToFile("index.html");
});

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = context =>
    {
        if (app.Environment.IsDevelopment())
            Console.WriteLine($"Requesting => {context.File.Name}");
        context.Context.Response.Headers.AccessControlAllowOrigin = "*";
        context.Context.Response.Headers.AccessControlAllowHeaders = "Origin, X-Requested-With, Content-Type, Accept";
    },
    ServeUnknownFileTypes = true,
});

app.MapControllers();
app.Run();