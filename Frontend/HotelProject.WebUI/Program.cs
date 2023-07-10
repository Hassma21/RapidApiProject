using FluentValidation;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateGuestValidator>();
builder.Services.AddMvc(config =>
{
    var policy =new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));

});//burada tüm controller'lara Authenticate olmalý diyoruz.tabi hepsinin olmamasý için istenilen controllerlara AllowAnonymous eklenebilir
//AllowAnonymous olan controllerlara Authenticate olmadan gidebiliriz
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromSeconds(100);
    options.LoginPath = "/Login/Index";
});//uygulamanýn gideceði ilk controller'ý belirlenir kullanýcýn ne kadar Authenticate olabileceðini belirleriz
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code ={0}");
app.UseHttpsRedirection();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
