using Chime.Shared.Infrastructure;
using Chime.Shared.Infrastructure.Contexts;
using Chime.Shared.Infrastructure.Contracts;
using Chime.Shared.Infrastructure.Modules;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureModules();

var assemblies = ModulesLoader.LoadAssemblies(builder.Configuration);
builder.Services.AddModularInfrastructure(assemblies);

var modules = ModulesLoader.LoadModules(assemblies);
foreach (var module in modules) module.Register(builder.Services);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

foreach (var module in modules) module.Use(app);

app.ValidateContracts(assemblies);

app.UseContext();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();