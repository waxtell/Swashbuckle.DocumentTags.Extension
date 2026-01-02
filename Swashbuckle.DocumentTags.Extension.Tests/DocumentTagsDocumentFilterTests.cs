using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;
using Xunit;

namespace Swashbuckle.DocumentTags.Extension.Tests;

public class DocumentTagsDocumentFilterTests
{
    [Theory, AutoData]
    public void NameAndDescriptionMatch(string description, string name)
    {
        var config = new DocumentTagsConfig
        {
            Tags =
            [
                new OpenApiTag
                {
                    Description = description, 
                    Name = name
                }
            ]
        };

        var subject = Subject(
            apiDescriptions: [],
            options: new SwaggerGeneratorOptions
            {
                SwaggerDocs = new Dictionary<string, OpenApiInfo>
                {
                    ["v1"] = new() { Version = "V1", Title = "Test API" }
                },
                DocumentFilters = new List<IDocumentFilter>
                {
                    new DocumentTagsDocumentFilter(config)
                }
            }
        );

        var document = subject.GetSwagger("v1");

        Assert.NotNull(document?.Tags);
        Assert.Single(document!.Tags);
        Assert.Equal(name,document.Tags.First().Name);
        Assert.Equal(description, document.Tags.First().Description);
    }

    private static SwaggerGenerator Subject(IEnumerable<ApiDescription> apiDescriptions, SwaggerGeneratorOptions options)
    {
        return 
            new SwaggerGenerator
            (
                options,
                new FakeApiDescriptionGroupCollectionProvider(apiDescriptions),
                new SchemaGenerator(new SchemaGeneratorOptions(), new JsonSerializerDataContractResolver(new JsonSerializerOptions()))
            );
    }
}
