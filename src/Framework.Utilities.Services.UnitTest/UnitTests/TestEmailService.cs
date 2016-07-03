// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestEmailService.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN All rights reserved.
// </copyright>
// <summary>
//   Defines the TestEmailService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace Framework.Utilities.Services.UnitTest.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Framework.Utilities.Services.Constants;
    using Framework.Utilities.Services.Enums;
    using Framework.Utilities.Services.Models;
    using Framework.Utilities.Services.Services;
    using Framework.Utilities.Services.UnitTest.Models;

    using NUnit.Framework;

    /// <summary>
    /// The test email service.
    /// </summary>
    public class TestEmailService
    {
        /// <summary>
        /// The test send email message.
        /// </summary>
        /// <param name="subject">
        /// The subject.
        /// </param>
        /// <param name="body">
        /// The body.
        /// </param>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <param name="fromName">
        /// The from name.
        /// </param>
        /// <param name="to">
        /// The to.
        /// </param>
        /// <param name="bcc">
        /// The bcc.
        /// </param>
        /// <param name="isHtml">
        /// The is html.
        /// </param>
        [TestCase("Testing SendEmailMessage", "Hi #NAME#", "noreply@gruden.com", "zhen.yuan", "zhen.yuan@gruden.com", "", true)]
        public void TestSendEmailMessage(
            string subject,
            string body,
            string from,
            string fromName,
            string to,
            string bcc,
            bool isHtml)
        {
            var tokens = new List<EmailToken> { new EmailToken() { Key = "#NAME#", Value = "ZHEN" } };
            
            var mailMessage = new EmailMessage(
                subject: subject, 
                body: body, 
                from: from, 
                fromName: fromName, 
                isHtml: isHtml, 
                to: to, 
                bcc: bcc, 
                tokens: tokens);

            EmailService.SendEmailMessage(mailMessage);
        }
    }
}
