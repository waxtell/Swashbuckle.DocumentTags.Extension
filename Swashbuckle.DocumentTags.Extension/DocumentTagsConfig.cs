using System.Collections.Generic;
using Microsoft.OpenApi;

namespace Swashbuckle.DocumentTags.Extension;

public class DocumentTagsConfig
{
    public IEnumerable<OpenApiTag> Tags { get; set; } = [];
}
