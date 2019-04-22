using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Envato.API.Tests
{
    [TestClass]
    public class AuthorizationRequestTests : TestBase
    {
        [TestMethod]
        public async Task Get_Code()
        {
            var result = await API.AuthorizationRequest.GetAccessToken(this.code, this.clientId, this.clientSecret);
        }
    }
}
