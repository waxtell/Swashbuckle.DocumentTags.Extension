using System.Collections.Generic;
using Microsoft.OpenApi.Models;

namespace Swashbuckle.DocumentTags.Extension
{
    public class DocumentTagsConfig
    {
        public IEnumerable<OpenApiTag> Tags { get; set; }
    }
}
