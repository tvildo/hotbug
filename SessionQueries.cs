using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;

namespace webapisample
{
    [ExtendObjectType(Name = "Query")]
    public class SessionQueries
    {
        public async Task<SimplePayload> GetViewerAsync(
        )
        {
            return await Task.FromResult(new SimplePayload("hello"));
        }
    }
}
