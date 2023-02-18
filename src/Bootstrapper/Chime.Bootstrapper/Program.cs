using Chime.Shared.Infrastructure;
using Chime.Shared.Infrastructure.API;
using Chime.Shared.Infrastructure.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .ConfigureApplicationPartManager(manager =>
    {
        manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
    });

var assemblies = ModulesLoader.LoadAssemblies(new ConfigurationManager());
var modules = ModulesLoader.LoadModules(assemblies);
foreach (var module in modules) module.Register(builder.Services);

builder.Services.AddModularInfrastructure(assemblies);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

foreach (var module in modules) module.Use(app);

app.MapControllers();

app.Run();