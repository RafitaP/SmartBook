using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SmartBook.Domain.Exceptions;
using SmartBook.Application.Interfaces;
using SmartBook.Persistence.Services;
using SmartBook.Persistence.Repositories;

using SmartBook.Application.Services;
using SmartBook.Persistence;

var builder = WebApplication.CreateBuilder(args);
var cfg = builder.Configuration;

builder.Services.AddDbContext<SmartBookDbContext>(o =>
    o.UseMySql(cfg.GetConnectionString("MySql"), ServerVersion.AutoDetect(cfg.GetConnectionString("MySql"))));

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuariosService, UsuariosService>();
builder.Services.AddScoped<IIngresoRepository, IngresoRepository>();
builder.Services.AddScoped<IIngresosService, IngresosService>();

builder.Services.AddScoped<IClientesService, ClientesService>();
builder.Services.AddScoped<ILibrosService, LibrosService>();
builder.Services.AddScoped<IIngresosService, IngresosService>();
builder.Services.AddScoped<IVentasService, VentasService>();
builder.Services.AddScoped<IInventarioService, InventarioService>();

var jwtKey = cfg["Jwt:Key"] ?? "CLAVE_CLAVE_CLAVE_CLAVE_CLAVE";
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = key,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.Use(async (ctx, next) =>
{
    try { await next(); }
    catch (BusinessRuleException bre)
    {
        ctx.Response.StatusCode = 422;
        await ctx.Response.WriteAsJsonAsync(new { error = bre.Message });
    }
    catch (Exception)
    {
        ctx.Response.StatusCode = 500;
        await ctx.Response.WriteAsJsonAsync(new { error = "Error interno" });
    }
});

app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/", () => Results.Redirect("/swagger"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
