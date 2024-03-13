using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using WebUI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterSqlContext(builder.Configuration);
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<RepositoryContext>()
    .AddDefaultTokenProviders();
builder.Services.AddHttpClient();
builder.Services.ConfigureValidator();
builder.Services.ConfigureAutoMapper();
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
})
    .AddFluentValidation();
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
}
);
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    options.AccessDeniedPath = "/ErrorPage/Index/";
    options.LoginPath = "/Admin/AdminLogin/Index/";

});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Default}/{action=Index}/{id?}");
});

app.Run();