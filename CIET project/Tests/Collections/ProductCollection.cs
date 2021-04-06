using Tests.Fixture;
using Xunit;

namespace Tests.Collections
{
    [CollectionDefinition("Product")]
    public class ProductCollection : ICollectionFixture<BaseFixture>
    {
    }
}
