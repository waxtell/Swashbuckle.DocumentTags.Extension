using System.Linq;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

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
            swaggerDoc.Tags = _config.Tags?.ToList();
        }
    }
}
