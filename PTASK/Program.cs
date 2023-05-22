using PTASK.Interface;
using PTASK.Reponsitory;
using PTASK.Extensions;

var builder = WebApplication.CreateBuilder(args);


//Get API
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();
var apiUrl = configuration.GetValue<string>("ApiUrl");

// API GET ALL
builder.Services.AddCustomHttpClient("apiAllProject", apiUrl);
builder.Services.AddCustomHttpClient("apiAllTask", apiUrl);
builder.Services.AddCustomHttpClient("apiAllMembers", apiUrl);
builder.Services.AddCustomHttpClient("apiAllTeams", apiUrl);
builder.Services.AddCustomHttpClient("apiGetAllWork", apiUrl);

// API CREATE
builder.Services.AddCustomHttpClient("apiCreateProject", apiUrl);
builder.Services.AddCustomHttpClient("apiCreateTeam", apiUrl);
builder.Services.AddCustomHttpClient("apiCreateWork", apiUrl);
builder.Services.AddCustomHttpClient("apiCreateTask", apiUrl);
builder.Services.AddCustomHttpClient("apiAddMember", apiUrl);
builder.Services.AddCustomHttpClient("apiCreateCommentWork", apiUrl);
builder.Services.AddCustomHttpClient("apiCreateCommentTask", apiUrl);

//API GET BY ...
builder.Services.AddCustomHttpClient("apiGetUserByEmail", apiUrl);
builder.Services.AddCustomHttpClient("apiGetProjectById", apiUrl);
builder.Services.AddCustomHttpClient("apiMembersByWorkId", apiUrl);
builder.Services.AddCustomHttpClient("apiGetTaskById", apiUrl);
builder.Services.AddCustomHttpClient("apiGetMemberByTeamId", apiUrl);
builder.Services.AddCustomHttpClient("apiGetWorkByName", apiUrl);
builder.Services.AddCustomHttpClient("apiGetUserByTaskId", apiUrl);
builder.Services.AddCustomHttpClient("apiGetProjectsByIdUser", apiUrl);
builder.Services.AddCustomHttpClient("apiGetUserById", apiUrl);
builder.Services.AddCustomHttpClient("apiGetWorkById", apiUrl);
builder.Services.AddCustomHttpClient("apiTasksByWorkId", apiUrl);
builder.Services.AddCustomHttpClient("apiGetTeamByWorkId", apiUrl);
builder.Services.AddCustomHttpClient("apiGetAllIdLeader", apiUrl);
builder.Services.AddCustomHttpClient("apiGetTeamById", apiUrl);
builder.Services.AddCustomHttpClient("apiGetCommentByTaskId", apiUrl);
builder.Services.AddCustomHttpClient("apiGetCommentByWorkId", apiUrl);

//API LOGIN
builder.Services.AddCustomHttpClient("apiLogin", apiUrl);
builder.Services.AddCustomHttpClient("apiRegister", apiUrl);

//DELETE
builder.Services.AddCustomHttpClient("removeWork", apiUrl);
builder.Services.AddCustomHttpClient("removeTask", apiUrl);
builder.Services.AddCustomHttpClient("removeProject", apiUrl);
builder.Services.AddCustomHttpClient("removeTeamInProject", apiUrl);
builder.Services.AddCustomHttpClient("removeMemberInProject", apiUrl);

//UPDATE
builder.Services.AddCustomHttpClient("changeStatusTask", apiUrl);
builder.Services.AddCustomHttpClient("changeStatusWork", apiUrl);
builder.Services.AddCustomHttpClient("apiUpdateTask", apiUrl);
builder.Services.AddCustomHttpClient("apiUpdateWork", apiUrl);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();

//Add session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//Register
builder.Services.AddSingleton<IProjectService, ProjectService>();
builder.Services.AddSingleton<IAuthService, AuthService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<ICommentService, CommentService>();
builder.Services.AddSingleton<IWorkService, WorkService>();
builder.Services.AddSingleton<ITaskService, TaskService>();
builder.Services.AddSingleton<ITeamService, TeamService>();
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
