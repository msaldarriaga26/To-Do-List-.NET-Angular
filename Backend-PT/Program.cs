using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PT.Data;
using PT.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// =====================
// 🔐 CONFIGURAR JWT
// =====================
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var key = builder.Configuration["JwtKey"]; // Tu clave secreta en appsettings.json

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!))
        };
    });

// ==============================
// 🔑 Registrar JwtService
// ==============================
builder.Services.AddSingleton<JwtService>();

// ==============================
// 🗄️ Registrar EF InMemory DB
// ==============================
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("TodoDB"));

// ==============================
// 📦 Controladores + Swagger
// ==============================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// ==============================
// 📘 Swagger con soporte JWT
// ==============================
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "PT API", Version = "v1" });

    // 🔒 Agregar botón Authorize
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Ingresa el token generado: Bearer {token}"
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// ==============================
// 🚀 Inicializar datos (Opcional)
// ==============================
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Usuario para pruebas
    db.Users.Add(new PT.Models.User
    {
        Email = "test@mail.com",
        Password = "123456"
    });

    db.SaveChanges();
}

// ==============================
// 🌐 Middlewares
// ==============================
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();
