using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

[assembly: InternalsVisibleTo("Swashbuckle.DocumentTags.Extension.Tests")]

namespace Swashbuckle.DocumentTags.Extension;

internal class DocumentTagsDocumentFilter(DocumentTagsConfig config) : IDocumentFilter
{
    private readonly DocumentTagsConfig _config = config;

    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        // Initialize collection if null (OpenAPI.NET v2 doesn't initialize collections by default)
        swaggerDoc.Tags ??= new HashSet<OpenApiTag>();
        
        // Add the configured tags
        foreach (var tag in _config.Tags)
        {
            swaggerDoc.Tags.Add(tag);
        }
    }
}
