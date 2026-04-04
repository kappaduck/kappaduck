// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace Web.App.Layouts;

public partial class MainLayout
{
    [JSImport("toggleTheme", "settings")]
    private static partial void ToggleTheme();

    [JSImport("initTheme", "settings")]
    private static partial void InitTheme();

    [SupportedOSPlatform("browser")]
    protected override async Task OnInitializedAsync()
    {
        await JSHost.ImportAsync("settings", "/scripts/settings.js");
        InitTheme();
    }
}
