using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>//Jwt Configurasyon
{
    opt.RequireHttpsMetadata = false;//?
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = "http://localhost",//yayýncýsý
        ValidAudience = "http://localhost",//dinleyicisi
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aspnetcorejwtjwt")),
        //aspnetcorejwtjwt authorize olunmasý gereken yerlerde  kullanýca buna sahipse iþlemi yapar.
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true, //token'ýn geçerlilik süresi olsun 
        ClockSkew =TimeSpan.Zero
        
    };
}
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
