#region License
// Copyright (c) 2019 Pierre Nortje
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace Envato.API.Requests
{
    public class RequestBase
    {
        #region Protected Fields
        protected readonly IRestClient restClient;

        protected readonly string clientId;
        protected readonly string clientSecret;

        protected readonly string token;
        #endregion

        #region Constructor
        public RequestBase(IRestClient restClient, string clientId, string clientSecret, string token)
        {
            this.restClient = restClient;
            this.clientId = clientId;
            this.clientSecret = clientSecret;

            this.token = token;
        }
        #endregion

        #region Public Properties
        public HttpStatusCode StatusCode { get; set; }
        public string StatusDescription { get; set; }
        #endregion

        #region Protected Methods
        protected async Task<TResponseType> ExecuteGet<TResponseType>(IRestRequest request)
        {
            if (!string.IsNullOrEmpty(this.token))
                request.AddHeader("Authorization", $"Bearer {this.token}");

            var response = await restClient.ExecuteTaskAsync<TResponseType>(request);

            StatusDescription = response.StatusDescription;
            StatusCode = response.StatusCode;

            return response.Data;
        }
        #endregion
    }
}
