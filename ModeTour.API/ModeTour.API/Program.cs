using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ModeTour.Commons;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
GlobalData.connectionStrNewAegle3 = Functions.Decrypt(builder.Configuration.GetConnectionString("NEWEAGLE3"));
GlobalData.connectionStrModeWeb3 = Functions.Decrypt(builder.Configuration.GetConnectionString("MODEWEB3"));
GlobalData.connectionStrModeWare3 = Functions.Decrypt(builder.Configuration.GetConnectionString("MODEWARE3"));
GlobalData.issuer = Functions.ToString(Functions.Decrypt(builder.Configuration["Jwt:Issuer"]));
GlobalData.audience = Functions.ToString(Functions.Decrypt(builder.Configuration["Jwt:Audience"]));
GlobalData.key = Functions.ToString(Functions.Decrypt(builder.Configuration["Jwt:Key"]));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = GlobalData.issuer,
        ValidAudience = GlobalData.audience,
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF32.GetBytes(GlobalData.key)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.AddAuthorization();


var app = builder.Build();
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


