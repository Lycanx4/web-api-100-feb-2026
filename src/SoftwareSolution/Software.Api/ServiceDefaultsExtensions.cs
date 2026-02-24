// Pseudocode / Plan:
// 1. Create a static extension class `ServiceDefaultsExtensions` in the `Software.Api` namespace so the method is discoverable from `Program.cs` without extra using directives.
// 2. Implement an extension method `AddServiceDefaults(this WebApplicationBuilder builder)`.
// 3. Validate `builder` is not null.
// 4. Register a small set of common, safe DI services that don't require extra packages (options, routing, http client, logging).
// 5. Return the builder to allow fluent usage (optional chaining).
// 6. Keep the implementation minimal to avoid introducing new external dependencies.
//
// This file adds the missing extension method so the call `builder.AddServiceDefaults();` in Program.cs compiles.

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Software.Api
{
    public static class ServiceDefaultsExtensions
    {
        /// <summary>
        /// Adds a small set of safe, common default services to the provided WebApplicationBuilder.
        /// This resolves the missing extension method error (CS1061) for `AddServiceDefaults`.
        /// Keep this minimal — add more registrations here only if those packages are referenced by the project.
        /// </summary>
        /// <param name="builder">The WebApplicationBuilder to configure.</param>
        /// <returns>The same builder instance for fluent chaining.</returns>
        public static WebApplicationBuilder AddServiceDefaults(this WebApplicationBuilder builder)
        {
            if (builder is null) throw new ArgumentNullException(nameof(builder));

            // Common service registrations that do not require additional nuget packages:
            builder.Services.AddOptions();
            builder.Services.AddRouting();
            builder.Services.AddHttpClient();
            builder.Services.AddLogging();

            // Do not add controllers/Swagger here if Program.cs already configures them.
            // Return the builder to allow chaining if desired.
            return builder;
        }
    }
}