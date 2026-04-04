// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

namespace Web.App.Projects;

public sealed record Project
{
    public required string Name { get; init; }

    public required ProjectType Type { get; init; }

    public required IEnumerable<string> Tags { get; init; }

    public required string Description { get; init; }

    public required Uri Url { get; init; }
}
