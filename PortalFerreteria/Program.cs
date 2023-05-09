using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PortalFerreteria;
using Radzen;
using Syncfusion.Blazor;
using Syncfusion.Licensing;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

#region Syncfusion

if (File.Exists(Directory.GetCurrentDirectory() + "/SyncfusionLicense.txt"))
{
    string licenseKey = File.ReadAllText(Directory.GetCurrentDirectory() + "/LicenciaSyncfusion2022.txt");
    SyncfusionLicenseProvider.RegisterLicense(licenseKey);
}

SyncfusionLicenseProvider.RegisterLicense("OTk4OTIyQDMyMzAyZTM0MmUzMG0wZFFub1hsaEFrcHlBQy9nVkpUQVAycVZNeWxCNnh5a3prSlBQZkZwN0k9;Mgo+DSMBaFt/QHRqVVhjVFpFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jSHxXd0BnXn9ZdX1WRg==;Mgo+DSMBPh8sVXJ0S0J+XE9HflRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31Td0dnWHpad3RSQGBbVw==;Mgo+DSMBMAY9C3t2VVhkQlFadVdJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkRhXX5bdHNVQWZeVUI=;OTk4OTI2QDMyMzAyZTM0MmUzMFJOcVhFM2N2T2FHRjJRRlVnUit3dmRRNGpLOXNiazNhdGgzWjNwa0NEUW89;OTk4OTI3QDMyMzAyZTM0MmUzMFg5U2tDd3Jva2xSZEFhaCtoQklhd0J2c2kyNVFtc1QwUlFjR2VQK3NXQ009");

builder.Services.AddSyncfusionBlazor();

#endregion

#region Radzen

    builder.Services.AddScoped<DialogService>();
    builder.Services.AddScoped<NotificationService>();
    builder.Services.AddScoped<TooltipService>();
    builder.Services.AddScoped<ContextMenuService>();

#endregion

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
