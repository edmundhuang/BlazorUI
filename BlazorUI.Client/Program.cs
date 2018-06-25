using BlazorUI.Client.Pages;
using BlazorUI.Client.Services;
using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BlazorUI.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(services =>
            {
                // Add any custom services here
                services.AddSingleton<AppState>();
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("body");
        }
    }
}
