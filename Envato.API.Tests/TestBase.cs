using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Envato.API.Tests
{
    [TestClass]
    public class TestBase
    {
        #region Private Fields
        private ApiRequest api;

        protected readonly string clientId = "[YOUR-CLIENT-ID]";
        protected readonly string clientSecret = "[YOUR-CLIENT-SECRET]";

        // To get the code oyu need to authorize Envato by gonig to this link:
        // https://api.envato.com/authorization?response_type=code&client_id=[CLIENT ID]&redirect_uri=[REDIRECT URI]
        // Note: The "redirect_uri" needs to be the one you specified when you created your app on Envato
        // After going to the URL, you'll be redirected to your URL. Use the "code" value in the URL here.
        protected readonly string code = "[YOUR-ACCESS-CODE]";

        protected readonly string token = "[YOUR-ACCESS-TOKEN]";
        #endregion

        #region Public Properties
        public ApiRequest API
        {
            get
            {
                return this.api;
            }
        }
        #endregion

        #region Public Methods
        [TestInitialize]
        public void Init()
        {
            this.api = new ApiRequest(clientId, clientSecret, token);
        }
        #endregion
    }
}
