using EducationPlatform.Web.Domain.Entity;
using EducationPlatform.Web.Helper;
using EducationPlatform.Web.Services;
using EducationPlatform.Web.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ILoginService, UserService>();
builder.Services.AddScoped<ICRUD<UserOutput, UserInput>, UserService>();
builder.Services.AddScoped<ICRUD<CourseOutput, CourseInput>, CourseService>();
builder.Services.AddScoped<ICRUD<BlockOutput, BlockInput>, BlockService>();
builder.Services.AddScoped<ICRUD<LessonOutput, LessonInput>, LessonService>();
builder.Services.AddScoped<ICRUD<SignatureOutput, SignatureInput>, SignatureService>();
builder.Services.AddSingleton<ISessao, Sessao>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddHttpContextAccessor();


builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});

builder.Services.AddHttpClient("EducationPlatform", c =>
c.BaseAddress = new Uri(builder.Configuration["ServiceUri:EducationPlatformAPI"]));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
