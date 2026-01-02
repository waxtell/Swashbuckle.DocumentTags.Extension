using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Swashbuckle.DocumentTags.Extension.Tests;

public class FakeApiDescriptionGroupCollectionProvider(IEnumerable<ApiDescription> apiDescriptions) : IApiDescriptionGroupCollectionProvider
{
    public ApiDescriptionGroupCollection ApiDescriptionGroups
    {
        get
        {
            var apiDescriptionGroups = apiDescriptions
                .GroupBy(item => item.GroupName)
                .Select(grouping => new ApiDescriptionGroup(grouping.Key, grouping.ToList()))
                .ToList();

            return new ApiDescriptionGroupCollection(apiDescriptionGroups, 1);
        }
    }
}
