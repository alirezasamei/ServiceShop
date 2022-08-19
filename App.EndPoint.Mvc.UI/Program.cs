using App.Domain.AppServices.BaseData;
using App.Domain.AppServices.Customer;
using App.Domain.AppServices.Service;
using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.ConfigurationModels;
using App.Domain.Core.Customer.Contracts.AppServices;
using App.Domain.Core.Customer.Contracts.Repositories;
using App.Domain.Core.Customer.Contracts.Services;
using App.Domain.Core.Expert.Contracts.AppServices;
using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Expert.Contracts.Services;
using App.Domain.Core.Permission.Contracts.Services;
using App.Domain.Core.Service.Contracts.AppServices;
using App.Domain.Core.Service.Contracts.Repositories;
using App.Domain.Core.Service.Contracts.Services;
using App.Domain.Services.BaseData;
using App.Domain.Services.Customer;
using App.Domain.Services.Expert;
using App.Domain.Services.Permission;
using App.Domain.Services.Service;
using App.EndPoint.Mvc.UI.Utilities;
using App.Infrastructure.Repos.Ef.BaseData;
using App.Infrastructure.Repos.Ef.Customer;
using App.Infrastructure.Repos.Ef.Expert;
using App.Infrastructure.Repos.Ef.Service;
using App.Infrastructure.SqlServer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddSeq(builder.Configuration.GetSection("Seq"));

builder.Services.AddDistributedMemoryCache();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddIdentity<AppUser, IdentityRole<int>>(
        options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedPhoneNumber = false;

            //options.User.AllowedUserNameCharacters
            //options.User.RequireUniqueEmail

            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 3;
            options.Password.RequiredUniqueChars = 1;

        })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddErrorDescriber<PersianDescriber>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/Login";
});

builder.Services.AddControllersWithViews();

#region BaseData
builder.Services.AddScoped<IAppUserCommandRepository, AppUserCommandRepository>();
builder.Services.AddScoped<IAppUserQueryRepository, AppUserQueryRepository>();
builder.Services.AddScoped<IFileCommandRepository, FileCommandRepository>();
builder.Services.AddScoped<IFileQueryRepository, FileQueryRepository>();
builder.Services.AddScoped<IFileTypeCommandRepository, FileTypeCommandRepository>();
builder.Services.AddScoped<IFileTypeQueryRepository, FileTypeQueryRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IFileAppService, FileAppService>();
builder.Services.AddScoped<IFileTypeService, FileTypeService>();
#endregion BaseData

#region Expert
builder.Services.AddScoped<ICommentCommandRepository, CommentCommandRepository>();
builder.Services.AddScoped<ICommentQueryRepository, CommentQueryRepository>();
builder.Services.AddScoped<IEvaluationCommandRepository, EvaluationCommandRepository>();
builder.Services.AddScoped<IEvaluationQueryRepository, EvaluationQueryRepository>();
builder.Services.AddScoped<IEvaluationTitleCommandRepository, EvaluationTitleCommandRepository>();
builder.Services.AddScoped<IEvaluationTitleQueryRepository, EvaluationTitleQueryRepository>();
builder.Services.AddScoped<IExpertCommandRepository, ExpertCommandRepository>();
builder.Services.AddScoped<IExpertQueryRepository, ExpertQueryRepository>();
builder.Services.AddScoped<IExpertServiceCommandRepository, ExpertServiceCommandRepository>();
builder.Services.AddScoped<IExpertServiceQueryRepository, ExpertServiceQueryRepository>();
builder.Services.AddScoped<IPastWorkCommandRepository, PastWorkCommandRepository>();
builder.Services.AddScoped<IPastWorkQueryRepository, PastWorkQueryRepository>();
builder.Services.AddScoped<ITenderCommandRepository, TenderCommandRepository>();
builder.Services.AddScoped<ITenderQueryRepository, TenderQueryRepository>();

builder.Services.AddScoped<ITenderService, TenderService>();
builder.Services.AddScoped<ITenderAppService, TenderAppService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentAppService, CommentAppService>();
builder.Services.AddScoped<IExpertServiceService, ExpertServiceService>();
builder.Services.AddScoped<IExpertServiceAppService, ExpertServiceAppService>();
builder.Services.AddScoped<IPastWorkService, PastWorkService>();
builder.Services.AddScoped<IPastWorkAppService, PastWorkAppService>();
#endregion Expert

#region Service
builder.Services.AddScoped<IServiceCommandRepository, ServiceCommandRepository>();
builder.Services.AddScoped<IServiceQueryRepository, ServiceQueryRepository>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IServiceAppService, ServiceAppService>();
#endregion Service

#region Customer
builder.Services.AddScoped<IOrderCommandRepository, OrderCommandRepository>();
builder.Services.AddScoped<IOrderQueryRepository, OrderQueryRepository>();
builder.Services.AddScoped<IOrderStateCommandRepository, OrderStateCommandRepository>();
builder.Services.AddScoped<IOrderStateQueryRepository, OrderStateQueryRepository>();
builder.Services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
builder.Services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderAppService, OrderAppService>();
builder.Services.AddScoped<IOrderStateService, OrderStateService>();
builder.Services.AddScoped<IOrderStateAppService, OrderStateAppService>();
#endregion Customer

builder.Services.AddDistributedMemoryCache();

builder.Services.Configure<AppDomainOption>(builder.Configuration.GetSection("AppDomian"));

builder.Services.AddScoped<IPermissionService, PermissionService>();
var app = builder.Build();
app.UseExceptionHandlerMiddleware();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    //app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapAreaControllerRoute(
    name: "areas",
    areaName: "Admin",
    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
