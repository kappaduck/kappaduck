// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.JSInterop;
using Web.App.Options;
using Web.App.Projects;

namespace Web.App;

internal static class HostExtensions
{
    extension(WebAssemblyHostBuilder builder)
    {
        internal void AddServices()
        {
            builder.UseDefaultServiceProvider((env, options) =>
            {
                options.ValidateOnBuild = true;
                options.ValidateScopes = env.IsDevelopment();
            });

            builder.ConfigureOptions();

            builder.Services.AddMemoryCache();
            builder.Services.AddSingleton(sp => (IJSInProcessRuntime)sp.GetRequiredService<IJSRuntime>());
            builder.Services.AddHttpClient<ProjectHttpClient>();
        }

        internal void ConfigureLoggings()
        {
            if (!builder.HostEnvironment.IsProduction())
                return;

            builder.Logging.ClearProviders();
        }

        private void ConfigureOptions()
        {
            builder.Services.Configure<CacheOptions>(builder.Configuration.GetRequiredSection(CacheOptions.Section))
                            .AddSingleton<IValidateOptions<CacheOptions>, CacheOptions.Validator>()
                            .AddSingleton(sp => sp.GetRequiredService<IOptions<CacheOptions>>().Value);

            builder.Services.Configure<ProjectOptions>(builder.Configuration.GetRequiredSection(ProjectOptions.Section))
                            .AddSingleton<IValidateOptions<ProjectOptions>, ProjectOptions.Validator>()
                            .AddSingleton(sp => sp.GetRequiredService<IOptions<ProjectOptions>>().Value);

            builder.Services.Configure<EndpointsOptions>(builder.Configuration.GetRequiredSection(EndpointsOptions.Section))
                            .AddSingleton<IValidateOptions<EndpointsOptions>, EndpointsOptions.Validator>()
                            .AddSingleton(sp => sp.GetRequiredService<IOptions<EndpointsOptions>>().Value);
        }
    }
}
