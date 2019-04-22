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

using Envato.API.Requests;
using RestSharp;
using System;

namespace Envato.API
{
    public class ApiRequest
    {
        #region Private Fields
        private readonly IRestClient client;

        protected readonly string clientId;
        protected readonly string clientSecret;

        private readonly string token;
        #endregion

        #region Constructor
        public ApiRequest(string clientId, string clientSecret, string token = null)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;

            this.token = token;

            this.client = new RestClient
            {
                BaseUrl = new Uri("https://api.envato.com/")
            };
        }
        #endregion

        #region Public Properties
        public AuthorizationRequest AuthorizationRequest { get { return new AuthorizationRequest(this.client, this.clientSecret, this.clientSecret); } }
        public SearchRequest SearchRequest { get { return new SearchRequest(this.client, this.clientSecret, this.clientSecret, this.token); } }
        #endregion
    }
}
