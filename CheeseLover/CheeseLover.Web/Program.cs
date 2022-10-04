using CheeseLover.Web;
using CheeseLover.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<CheeseService>(
                    client =>
                    {
                        client.BaseAddress = new Uri("http://localhost:64171/");
                        client.DefaultRequestHeaders.Add("Accept", "application/json");
                    });

await builder.Build().RunAsync();
