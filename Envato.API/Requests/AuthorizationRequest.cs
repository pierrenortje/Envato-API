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

using Envato.API.Interfaces;
using Envato.API.Models;
using RestSharp;
using System.Threading.Tasks;

namespace Envato.API.Requests
{
    public class AuthorizationRequest : RequestBase, IAuthorizationRequest
    {
        public AuthorizationRequest(IRestClient client, string clientId, string clientSecret) : base(client, clientId, clientSecret, token: null) { }

        public async Task<TokenResponse> GetAccessToken(string code, string clientId, string clientSecret)
        {
            var request = new RestRequest("token", Method.POST);
            request.AddParameter("application/x-www-form-urlencoded", $"grant_type=authorization_code&code={code}&client_id={clientId}&client_secret={clientSecret}", ParameterType.RequestBody);

            return await base.ExecuteGet<TokenResponse>(request);
        }

        public async Task<TokenResponse> GetRefreshToken(string refreshToken, string clientId, string clientSecret)
        {
            var request = new RestRequest("token", Method.POST);
            request.AddParameter("application/x-www-form-urlencoded", $"grant_type=refresh_token&refreshToken={refreshToken}&client_id={clientId}&client_secret={clientSecret}", ParameterType.RequestBody);

            return await base.ExecuteGet<TokenResponse>(request);
        }
    }
}
