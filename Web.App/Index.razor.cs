// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using Web.App.Projects;

namespace Web.App;

public sealed partial class Index(ProjectHttpClient client) : IDisposable
{
    private readonly CancellationTokenSource _tokenSource = new();

    private IEnumerable<Project> _projects = [];
    private IEnumerable<ProjectType> _types = [];
    private ProjectType? _selectedType;

    private IEnumerable<Project> FilteredProjects
        => [.. _projects.Where(p => _selectedType is null || p.Type == _selectedType).OrderBy(p => p.Name)];

    protected override async Task OnInitializedAsync()
    {
        _projects = await client.GetAllAsync(_tokenSource.Token);
        _types = [.. _projects.Select(p => p.Type).Distinct().Order()];
    }

    private void SelectProjectType(ProjectType type) => _selectedType = type;

    private string IsTypeActiveCss(ProjectType? type)
        => _selectedType == type ? "active" : string.Empty;

    public void Dispose()
    {
        if (_tokenSource.IsCancellationRequested)
            return;

        _tokenSource.Cancel();
        _tokenSource.Dispose();
    }
}
