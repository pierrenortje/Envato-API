using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Envato.API.Tests
{
    [TestClass]
    public class SearchRequestTests : TestBase
    {
        [TestMethod]
        public async Task Search_Item()
        {
            var result = await API.SearchRequest.Item("store", "codecanyon.net");
        }
    }
}
