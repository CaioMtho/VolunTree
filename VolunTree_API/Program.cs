using Dapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using VolunTree_API.Services;
using System.Text.Json;
using VolunTree_API.Mappings;
using VolunTree_API.Models;
using VolunTree_API.Pages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Configura��o das portas Kestrel
builder.WebHost.UseKestrel(options =>
{
    options.ListenAnyIP(5114);
    options.ListenAnyIP(7071, listenOptions =>
    {
        listenOptions.UseHttps();
    });
});

// Configura��o de Servi�os
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Voluntree API", Version = "v1" });
});

SqlMapper.SetTypeMap(typeof(Voluntario), new CustomMapper(typeof(Voluntario)));
SqlMapper.SetTypeMap(typeof(Ong), new CustomMapper(typeof(Ong)));
SqlMapper.SetTypeMap(typeof(VoluntarioOng), new CustomMapper(typeof(VoluntarioOng)));
SqlMapper.SetTypeMap(typeof(Sugestao), new CustomMapper(typeof(Sugestao)));

builder.Services.AddHttpClient<CadastroOngModel>();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IDataService, DataService>();

// Configura��o de Autentica��o e Autoriza��o
builder.Services.AddScoped<UsuarioAutenticado>();
builder.Services.AddScoped<CnpjService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

var app = builder.Build();

// Configura��o do Pipeline de Requisi��es
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "VolunTree API");
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
