using log4net.Config;
using log4net;
using STPL.Common.Log;
using STPL.WebAPI.Extension;
using STPL.AppService.Extension;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
builder.Configuration
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton(LogManager.GetLogger(typeof(Program)));
//builder.Logging.AddLog4Net();
builder.Services.AddCors(builder.Configuration);
builder.Services.DBConfig(builder.Configuration);

builder.Services.AddScoped<LogService>();
builder.Services.AddService();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "STPL", Version = "v1" });
});
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
