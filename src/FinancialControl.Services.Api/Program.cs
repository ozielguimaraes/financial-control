using FinancialControl.Infra.CrossCutting.IoC;
using FinancialControl.Infra.CrossCutting.Security.Builders;
using FinancialControl.Infra.CrossCutting.Security.Data;
using FinancialControl.Infra.CrossCutting.Security.Extensions;
using FinancialControl.Services.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterServices(builder.Configuration);

builder.Services.AddIdentityConfiguration(builder.Configuration);
//builder.Services.AddAuthenticationConfig(builder.Configuration);

builder.Services.AddApiConfig();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.ToString());
});

// Configure JSON logging to the console.
builder.Logging.AddJsonConsole();


var app = builder.Build();

MigrationHelper.EnsureSeedData(app).Wait();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Development");
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseCors("Production");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseSecurityHeadersMiddleware(new SecurityHeadersBuilder().AddDefaultSecurePolicy());
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
