using Dapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using VolunTree_API.Services;
using System.Text.Json;
using VolunTree_API.Mappings;
using VolunTree_API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseKestrel(options =>
{
    options.ListenAnyIP(5114);
    options.ListenAnyIP(7071, listenOptions =>
    {
        listenOptions.UseHttps();
    });
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

SqlMapper.SetTypeMap(typeof(Voluntario), new CustomMapper(typeof(Voluntario)));
SqlMapper.SetTypeMap(typeof(Ong), new CustomMapper(typeof(Ong)));
SqlMapper.SetTypeMap(typeof(VoluntarioOng), new CustomMapper(typeof(VoluntarioOng)));
SqlMapper.SetTypeMap(typeof(Sugestao), new CustomMapper(typeof(Sugestao)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.MapControllers();
app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
