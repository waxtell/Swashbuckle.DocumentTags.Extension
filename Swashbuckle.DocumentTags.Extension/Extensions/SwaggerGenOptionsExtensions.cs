using System;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

// ReSharper disable once CheckNamespace
namespace Swashbuckle.DocumentTags.Extension
{
    public static class SwaggerGenOptionsExtensions
    {
        public static void WithDocumentTags(this SwaggerGenOptions swaggerGenOptions,
            Action<DocumentTagsConfig> setupAction)
        {
            var options = new DocumentTagsConfig();

            setupAction.Invoke(options);

            swaggerGenOptions.DocumentFilter<DocumentTagsDocumentFilter>(options);
        }
    }
}
