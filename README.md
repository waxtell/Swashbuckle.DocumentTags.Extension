# Swashbuckle.DocumentTags.Extension
Add document level Tags to your OAS!

Adding document level tags to your OAS:

```csharp
            services.AddSwaggerGen(c =>
            {
                c.WithDocumentTags
                (
                    dtc => dtc.Tags = new[]
                    {
                        new OpenApiTag { Name = "Products", Description = "Browse/manage the product catalog" },
                        new OpenApiTag { Name = "Orders", Description = "Submit orders" }
                    }
                );
```
