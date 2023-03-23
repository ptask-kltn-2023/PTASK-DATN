using PTASK.Interface;
using PTASK.Models;
using PTASK.Reponsitory;
using PTASK.Extensions;

var builder = WebApplication.CreateBuilder(args);


//Get API
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();
var apiUrl = configuration.GetValue<string>("ApiUrl");

builder.Services.AddCustomHttpClient("apiAllProject", apiUrl);
builder.Services.AddCustomHttpClient("apiLogin", apiUrl);
builder.Services.AddCustomHttpClient("apiRegister", apiUrl);
builder.Services.AddCustomHttpClient("apiCreateProject", apiUrl);
builder.Services.AddCustomHttpClient("apiGetUserByEmail", apiUrl);
builder.Services.AddCustomHttpClient("apiGetProjectById", apiUrl);
builder.Services.AddCustomHttpClient("apiGetAllWork", apiUrl);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddHttpContextAccessor();

//Add session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Set Jwt
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(jwtSettings);

//Register
builder.Services.AddSingleton<IProjectService, ProjectService>();
builder.Services.AddSingleton<IAuthService, AuthService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IWorkService, WorkService>();
builder.Services.AddSingleton<IJwtService, JwtService>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
