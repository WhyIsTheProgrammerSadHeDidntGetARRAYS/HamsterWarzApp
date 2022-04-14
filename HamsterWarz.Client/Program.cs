using HamsterWarz.Client;
using HamsterWarz.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7026/") });
builder.Services.AddMudServices();
builder.Services.AddScoped<IHamsterServiceClient, HamsterServiceClient>();

await builder.Build().RunAsync();
