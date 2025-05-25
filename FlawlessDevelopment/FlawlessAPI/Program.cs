//using FlawlessDevelopment.Shared.Services;
//using Microsoft.Azure.Functions.Worker.Builder;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;

//var builder = FunctionsApplication.CreateBuilder(args);

////builder.ConfigureFunctionsWebApplication();


//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(policy =>
//    {
//        policy.AllowAnyOrigin()
//              .AllowAnyHeader()
//              .AllowAnyMethod();
//    });
//});


////builder.Services.AddScoped<IInventoryService, InventoryService>();

////App.UseCors();

//builder.Build().Run();
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using FlawlessDevelopment.Shared.Services;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        // Register your dependencies, e.g.:
        //services.AddScoped<IInventoryService, InventoryService>();

        services.AddCors();
    })
    .Build();

host.Run();
