// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

namespace Web.App.Projects;

public enum ProjectType
{
    App = 0,
    Emulator = 1,
    Game = 2,
    Libraries = 3,
    Tools = 4
}

public static class ProjectTypeExtensions
{
    extension(ProjectType type)
    {
        internal string Name => type switch
        {
            ProjectType.App => nameof(ProjectType.App),
            ProjectType.Emulator => nameof(ProjectType.Emulator),
            ProjectType.Game => nameof(ProjectType.Game),
            ProjectType.Libraries => nameof(ProjectType.Libraries),
            ProjectType.Tools => nameof(ProjectType.Tools)
        };
    }
}
