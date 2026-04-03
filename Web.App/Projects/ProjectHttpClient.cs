// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using Microsoft.Extensions.Caching.Memory;
using System.Net.Http.Json;
using Web.App.Options;

namespace Web.App.Projects;

public sealed class ProjectHttpClient(HttpClient client, IMemoryCache cache, EndpointsOptions options, CacheOptions cacheOptions)
{
    private const string Key = "projects";

    internal async ValueTask<IEnumerable<Project>> GetAllAsync(CancellationToken cancellationToken)
    {
        if (cache.TryGetValue(Key, out IEnumerable<Project>? cachedProjects))
            return cachedProjects!;

        using HttpResponseMessage response = await client.GetAsync(options.Projects, cancellationToken);

        if (!response.IsSuccessStatusCode)
            return [];

        IEnumerable<Project>? projects = await response.Content.ReadFromJsonAsync(ProjectJsonContext.Default.IEnumerableProject, cancellationToken);

        if (projects is null)
            return [];

        cache.Set(Key, projects, TimeSpan.FromMinutes(cacheOptions.ExpirationTimeInMinutes));
        return projects;
    }
}
