// Copyright (c) KappaDuck. All rights reserved.
// The source code is licensed under MIT License.

using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Web.App.Options;

[ExcludeFromCodeCoverage]
public sealed partial class EndpointsOptions
{
    internal const string Section = "endpoints";

    [Required, Url]
    public required string Projects { get; set; }

    [OptionsValidator]
    internal sealed partial class Validator : IValidateOptions<EndpointsOptions>;
}
