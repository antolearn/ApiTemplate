using Api.Startup;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.File(path: @"C:\Users\Anthonydas\source\repos\Projects\Logs\ProgramTypelog-.txt",
    outputTemplate: "[{Timestamp:o}] [{Level,3:u}] [{MachineName}/{ProcessName}:{ProcessId}/{ThreadName}:{ThreadId}] [{Application}/{SourceContext}] {Message}{NewLine}{Exception}{Properties:j}",
    rollingInterval: RollingInterval.Day,
    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.RegisterDependencyServices();
builder.Services.RegisterDbServices(builder);
builder.Services.RegisterAppServices();
builder.Services.RegisterApiServices();

var app = builder.Build();
var env = builder.Environment;

// Configure the HTTP request pipeline.
app.ConfigureExceptionHandler(env);
//app.ConfigureCors();
app.ConfigureSwagger();
app.UseHttpsRedirection();
app.UseCors("AllowAllPolicy");
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapProgramTypeEndpoints();


app.Run();
