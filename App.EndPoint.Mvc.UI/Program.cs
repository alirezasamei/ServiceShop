using App.Domain.AppServices;
using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.Expert.Contracts.Repositories;
using App.Domain.Core.Operator.Contracts.Repositories;
using App.Domain.Core.Service.Contracts.Repositories;
using App.Domain.Core.User.Contracts.Repositories;
using App.Infrastructure.Repos.Ef.BaseData;
using App.Infrastructure.Repos.Ef.Expert;
using App.Infrastructure.Repos.Ef.Operator;
using App.Infrastructure.Repos.Ef.Service;
using App.Infrastructure.Repos.Ef.User;
using App.Infrastructure.SqlServer.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllersWithViews();


#region BaseData
builder.Services.AddScoped<IFileTypeCommandRepository            ,FileTypeCommandRepository         >();
builder.Services.AddScoped<IFileTypeQueryRepository              ,FileTypeQueryRepository           >();
#endregion BaseData

#region Expert
builder.Services.AddScoped<ICommentCommandRepository          ,CommentCommandRepository          >();
builder.Services.AddScoped<ICommentQueryRepository            ,CommentQueryRepository            >();
builder.Services.AddScoped<IEvaluationCommandRepository       ,EvaluationCommandRepository       >();
builder.Services.AddScoped<IEvaluationQueryRepository         ,EvaluationQueryRepository         >();
builder.Services.AddScoped<IEvaluationTitleCommandRepository  ,EvaluationTitleCommandRepository  >();
builder.Services.AddScoped<IEvaluationTitleQueryRepository    ,EvaluationTitleQueryRepository    >();
builder.Services.AddScoped<IExpertCommandRepository           ,ExpertCommandRepository           >();
builder.Services.AddScoped<IExpertQueryRepository             ,ExpertQueryRepository             >();
builder.Services.AddScoped<IExpertServiceCommandRepository    ,ExpertServiceCommandRepository    >();
builder.Services.AddScoped<IExpertServiceFileCommandRepository,ExpertServiceFileCommandRepository>();
builder.Services.AddScoped<IExpertServiceFileQueryRepository  ,ExpertServiceFileQueryRepository  >();
builder.Services.AddScoped<IExpertServiceQueryRepository      ,ExpertServiceQueryRepository      >();
builder.Services.AddScoped<IPastWorkCommandRepository         ,PastWorkCommandRepository         >();
builder.Services.AddScoped<IPastWorkQueryRepository           ,PastWorkQueryRepository           >();
builder.Services.AddScoped<ITenderCommandRepository           ,TenderCommandRepository           >();
builder.Services.AddScoped<ITenderQueryRepository             ,TenderQueryRepository             >();
#endregion Expert

#region Operator
builder.Services.AddScoped<IOperatorCommandRepository         ,OperatorCommandRepository         >();
builder.Services.AddScoped<IOperatorQueryRepository           ,OperatorQueryRepository           >();
#endregion Operator

#region Service
builder.Services.AddScoped<IServiceCommandRepository          ,ServiceCommandRepository          >();
builder.Services.AddScoped<IServiceFileCommandRepository      ,ServiceFileCommandRepository      >();
builder.Services.AddScoped<IServiceFileQueryRepository        ,ServiceFileQueryRepository        >();
builder.Services.AddScoped<IServiceQueryRepository            ,ServiceQueryRepository            >();
#endregion Service

#region User
builder.Services.AddScoped<IOrderCommandRepository            ,OrderCommandRepository            >();
builder.Services.AddScoped<IOrderQueryRepository              ,OrderQueryRepository              >();
builder.Services.AddScoped<IOrderStateCommandRepository       ,OrderStateCommandRepository       >();
builder.Services.AddScoped<IOrderStateQueryRepository         ,OrderStateQueryRepository         >();
builder.Services.AddScoped<IUserCommandRepository             ,UserCommandRepository             >();
builder.Services.AddScoped<IUserQueryRepository               ,UserQueryRepository               >();
#endregion User
builder.Services.AddScoped<SeedData>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
