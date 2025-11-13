// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

namespace Web.App;

internal static class HostExtensions
{
    extension(WebAssemblyHostBuilder builder)
    {
        internal void ConfigureLoggings()
        {
            if (!builder.HostEnvironment.IsProduction())
                return;

            builder.Logging.ClearProviders();
        }

        internal void ConfigureServices()
        {
            builder.UseDefaultServiceProvider((env, options) =>
            {
                options.ValidateOnBuild = true;
                options.ValidateScopes = env.IsDevelopment();
            });

            builder.Services.AddSingleton(sp => (IJSInProcessRuntime)sp.GetRequiredService<IJSRuntime>());
            builder.Services.AddLocalization();
        }
    }
}
