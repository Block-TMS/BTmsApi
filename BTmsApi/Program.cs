using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using BTmsApi.Models;
using BTmsApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);


var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "ApiAppIssuer",
            ValidAudience = "ApiAppAudience",
            IssuerSigningKey = new SymmetricSecurityKey("b0493a0d-f88e-4b0b-94eb-665f7207c92c"u8.ToArray()),
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("require-employee-role", policy =>
        policy.RequireRole("Admin", "Employee"));
    options.AddPolicy("require-admin-role", policy =>
        policy.RequireRole("Admin"));
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<SharedContext>(opt =>
{
    opt.UseMySql("server=localhost;port=3306;database=block-db;user=THOMAS;password=password;",
        new MySqlServerVersion(new Version(8, 0, 26))); // Specify the MySQL server version here
});

builder.Services.AddScoped<IUserService, UserService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<SharedContext>();

    context.Database.Migrate();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(myAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
