using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ExpenseApprovalSystem.Client;
using ExpenseApprovalSystem.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5222/")
});

builder.Services.AddScoped<AuthApiService>();
builder.Services.AddScoped<AuthStateService>();
builder.Services.AddScoped<ExpenseApiService>();

await builder.Build().RunAsync();
