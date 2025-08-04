using GM.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Configura��o do builder para incluir diferentes fontes de configura��o
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

// Configura��o de servi�os
builder.Services.AddIdentityConfiguration();
builder.Services.AddMvcConfiguration(builder.Configuration);
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

// Configura��o do pipeline de requisi��o HTTP
app.UseMvcConfiguration(app.Environment);

app.Run();