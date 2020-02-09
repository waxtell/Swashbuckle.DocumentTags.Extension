# Swashbuckle.DocumentTags.Extension
Add document level Tags to your OAS!

![Publish to nuget](https://github.com/waxtell/Swashbuckle.DocumentTags.Extension/workflows/Publish%20to%20nuget/badge.svg?branch=master)

Adding document level tags to your OAS:

```csharp
            services.AddSwaggerGen(c =>
            {
                c.WithDocumentTags
                (
                    new[]
                    {
                        new OpenApiTag { Name = "Products", Description = "Browse/manage the product catalog" },
                        new OpenApiTag { Name = "Orders", Description = "Submit orders" }
                    }
                );
```
