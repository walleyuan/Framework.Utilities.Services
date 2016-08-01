// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestMakeRequestsService.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN All rights reserved.
// </copyright>
// <summary>
//   Defines the TestMakeRequestsService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Utilities.Services.UnitTest.UnitTests
{
    using System.Collections.Generic;
    using Constants;
    using Enums;
    using Models;
    using NUnit.Framework;
    using Services;

    /// <summary>
    /// The test make requests service.
    /// </summary>
    [TestFixture]
    public class TestMakeRequestsService
    {
        /// <summary>
        /// The test get authenticate token.
        /// </summary>
        /// <param name="requestUri">
        /// The request uri.
        /// </param>
        /// <param name="requestBody">
        /// The request body.
        /// </param>
        [TestCase("http://hlra_uw.axegroup.biz/UWworkflow.WebAPI/Token", "grant_type=password&username=cues@hlra.com.au&password=Hlra1234!")]
        public void TestGetAuthenticateToken(string requestUri, string requestBody)
        {
            var token = MakeRequestsService.GetAuthenticateToken<AuthenticationToken>(RequestMethod.Post, RequestConstants.ContentType.Text, requestUri, requestBody);

            Assert.IsNotEmpty(token.AccessToken);
        }

        /// <summary>
        /// The test make request.
        /// </summary>
        /// <param name="requestUri">
        /// The request uri.
        /// </param>
        [TestCase("http://hlra_uw.axegroup.biz/UWworkflow.WebAPI/api/v1/groupapplications?page=1&perpage=1&sort=LastActionDate%20desc&status=Blank")]
        
        public void TestMakeRequest(string requestUri)
        {
            string tokenUri = "http://hlra_uw.axegroup.biz/UWworkflow.WebAPI/Token";

            string tokenBody = "grant_type=password&username=cues@hlra.com.au&password=Hlra1234!";

            var token = MakeRequestsService.GetAuthenticateToken<AuthenticationToken>(RequestMethod.Post, RequestConstants.ContentType.Text, tokenUri, tokenBody);

            var response  = MakeRequestsService.Get<List<Underwriting>>(RequestConstants.ContentType.Text, requestUri, token.AccessToken);

            Assert.IsTrue(response.Count > 0);
        }

        [TestCase("http://hlra_uw.axegroup.biz/UWworkflow.WebAPI/api/v1/groupapplications/697")]
        public void TestMakeRequestForGroupApplicatoin(string requestUri)
        {
            string tokenUri = "http://hlra_uw.axegroup.biz/UWworkflow.WebAPI/Token";

            string tokenBody = "grant_type=password&username=cues@hlra.com.au&password=Hlra1234!";

            var token = MakeRequestsService.GetAuthenticateToken<AuthenticationToken>(RequestMethod.Post, RequestConstants.ContentType.Text, tokenUri, tokenBody);

            var response = MakeRequestsService.Get<UnderwritingResponse>(RequestConstants.ContentType.Text, requestUri, token.AccessToken);

            Assert.IsTrue(response != null);
        }

        /// <summary>
        /// The test make async request.
        /// </summary>
        /// <param name="requestUri">
        /// The request uri.
        /// </param>
        [TestCase("http://hlra_uw.axegroup.biz/UWworkflow.WebAPI/api/v1/groupapplications/search?page=1&perpage=15&sort=LastActionDate%20desc&keyword=2&fund=GL4203")]
        public void TestMakeAsyncRequest(string requestUri)
        {
            string tokenUri = "http://hlra_uw.axegroup.biz/UWworkflow.WebAPI/Token";

            string tokenBody = "grant_type=password&username=cues@hlra.com.au&password=Hlra1234!";

            var token = MakeRequestsService.GetAuthenticateToken<AuthenticationToken>(RequestMethod.Post, RequestConstants.ContentType.Text, tokenUri, tokenBody);

            var response = MakeRequestsService.MakeAsyncRequest<List<Underwriting>>(RequestConstants.ContentType.Text, requestUri, token.AccessToken);

            Assert.IsTrue(response.Result.Count > 0);
        }
    }
}
