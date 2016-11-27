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
    }
}
