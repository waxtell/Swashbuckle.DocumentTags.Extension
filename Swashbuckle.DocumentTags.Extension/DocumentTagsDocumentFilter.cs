using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

[assembly: InternalsVisibleTo("Swashbuckle.DocumentTags.Extension.Tests")]
namespace Swashbuckle.DocumentTags.Extension
{

    internal class DocumentTagsDocumentFilter : IDocumentFilter
    {
        private readonly DocumentTagsConfig _config;

        public DocumentTagsDocumentFilter(DocumentTagsConfig config)
        {
            _config = config;
        }

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var joinedTagsList = new List<OpenApiTag>(swaggerDoc.Tags);
            
            joinedTagsList.AddRange(_config.Tags);

            swaggerDoc.Tags = joinedTagsList;
        }
    }
}
