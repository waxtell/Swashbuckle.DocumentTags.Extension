using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Swashbuckle.DocumentTags.Extension.Tests;

public class FakeApiDescriptionGroupCollectionProvider(IEnumerable<ApiDescription> apiDescriptions) : IApiDescriptionGroupCollectionProvider
{
    private readonly IEnumerable<ApiDescription> _apiDescriptions = apiDescriptions;

    public ApiDescriptionGroupCollection ApiDescriptionGroups
    {
        get
        {
            var apiDescriptionGroups = _apiDescriptions
                .GroupBy(item => item.GroupName)
                .Select(grouping => new ApiDescriptionGroup(grouping.Key, grouping.ToList()))
                .ToList();

            return new ApiDescriptionGroupCollection(apiDescriptionGroups, 1);
        }
    }
}
