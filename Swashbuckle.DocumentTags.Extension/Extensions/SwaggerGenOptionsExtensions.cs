using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

// ReSharper disable once CheckNamespace
namespace Swashbuckle.DocumentTags.Extension;

public static class SwaggerGenOptionsExtensions
{
    public static void WithDocumentTags(this SwaggerGenOptions swaggerGenOptions,
        Action<DocumentTagsConfig> setupAction)
    {
        var options = new DocumentTagsConfig();

        setupAction.Invoke(options);

        swaggerGenOptions.DocumentFilter<DocumentTagsDocumentFilter>(options);
    }
    public static void WithDocumentTags(this SwaggerGenOptions swaggerGenOptions,
        IEnumerable<OpenApiTag> tags)
    {
        var options = new DocumentTagsConfig
        {
            Tags = tags
        };

        swaggerGenOptions.DocumentFilter<DocumentTagsDocumentFilter>(options);
    }
}
