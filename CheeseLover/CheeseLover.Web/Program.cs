using Blazored.LocalStorage;
using CheeseLover.Web;
using CheeseLover.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<CheeseService>(
                    client =>
                    {
                        client.BaseAddress = new Uri("https://localhost:7293/");
                        client.DefaultRequestHeaders.Add("Accept", "application/json");
                    });

builder.Services.AddHttpClient<CartService>(
                    client =>
                    {
                        client.BaseAddress = new Uri("https://localhost:7293/");
                        client.DefaultRequestHeaders.Add("Accept", "application/json");
                    });

await builder.Build().RunAsync();
