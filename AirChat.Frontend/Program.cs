using AirChat.API.Services;
using AirChat.Frontend;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
var client = new AirChatServiceClient(new HttpClient { BaseAddress = new Uri("https://localhost:7155") });
builder.Services.AddSingleton(client);

await builder.Build().RunAsync();
