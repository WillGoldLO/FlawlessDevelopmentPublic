using FlawlessByDesign;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{ BaseAddress = new Uri("https://localhost:7068/") });

//builder.Services.AddAuthorizationCore(options =>
//{
//    options.AddPolicy("AdminOnly", policy => policy.RequireRole("admin"));
//});

await builder.Build().RunAsync();
