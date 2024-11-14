using SM.Infrastructure.EFCore.Extentions;
using SM.Application.Extentions;
using _01_LampShadeQuery.Extentions;
using DiscountManagement.Infrastructure.Coniguration;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddInfrastructureConfiguration(builder.Configuration);
builder.Services.AddApplicationDependencies();
builder.Services.AddQueryConfigration();

DiscountManagement.Infrastructure.Coniguration.DiscountManagement.Configure(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
