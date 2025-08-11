using GM.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Configuração do builder para incluir diferentes fontes de configuração
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

// Configuração de serviços
builder.Services.AddIdentityConfiguration();
builder.Services.AddMvcConfiguration(builder.Configuration);
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

// Configuração do pipeline de requisição HTTP
app.UseMvcConfiguration(app.Environment);

app.Run();