using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using DependencyInjectionDemo.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//builder.Services.AddTransient<DemoLogic>(); //new instance everytime
//builder.Services.AddSingleton<DemoLogic>(); //singleton
//builder.Services.AddScoped<IDemoLogic, DemoLogic>(); //each instance have their singleton(localize), per connection(per user)
//builder.Services.AddTransient<IDemoLogic, BetterDemoLogic>(); //with one change now change entire application
builder.Services.AddTransient<IDemoLogic, DemoLogic>(); //how easy it is to change dependencies around


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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
