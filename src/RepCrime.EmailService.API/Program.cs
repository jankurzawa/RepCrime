

var builder = WebApplication.CreateBuilder(args);

string kvURL = builder.Configuration["KeyVaultConfig:KVUrl"];
string tenantId = builder.Configuration["KeyVaultConfig:TenantId"];
string clientId = builder.Configuration["KeyVaultConfig:ClientId"];
string clientSecret = builder.Configuration["KeyVaultConfig:ClientSecretId"];

var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);

var client = new SecretClient(new Uri(kvURL), credential);

builder.Configuration.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());
builder.Services.AddCustomServices();
builder.Services.AddCustomMiddleware();

var emailConfig = builder.Configuration
        .GetSection("EmailConfiguration")
        .Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomMiddlewares();
app.UseAuthorization();
app.MapControllers();

app.Run();
