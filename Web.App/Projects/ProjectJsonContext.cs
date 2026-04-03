// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using System.Text.Json.Serialization;

namespace Web.App.Projects;

[JsonSerializable(typeof(IEnumerable<Project>))]
[JsonSourceGenerationOptions(
    PropertyNameCaseInsensitive = true,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    UseStringEnumConverter = true)]
internal sealed partial class ProjectJsonContext : JsonSerializerContext;
