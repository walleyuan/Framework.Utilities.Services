// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailMessage.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN All rights reserved.
// </copyright>
// <summary>
//   Defines the EmailMessage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Utilities.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Services;

    /// <summary>
    /// The email message.
    /// </summary>
    public class EmailMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailMessage"/> class.
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
        /// Is HTML format.
        /// </param>
        /// <param name="tokens">
        /// The tokens.
        /// </param>
        /// <param name="attachments">
        /// The attachments.
        /// </param>
        public EmailMessage(
            string subject,
            string body,
            string from,
            string fromName,
            string to,
            string bcc,
            bool isHtml = true,
            IEnumerable<EmailToken> tokens = null,
            string[] attachments = null)
        {
            this.Subject = subject;
            this.Body = body;
            this.From = from;
            this.FromName = fromName;
            this.To = to;
            this.IsHtml = isHtml;
            this.Bcc = bcc;
            this.Tokens = tokens;
            this.AttachmentFilePaths = attachments;
        }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the from.
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// Gets or sets the from name.
        /// </summary>
        public string FromName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is html email.
        /// </summary>
        public bool IsHtml { get; set; }

        /// <summary>
        /// Gets or sets the to.
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Gets or sets the bcc.
        /// </summary>
        public string Bcc { get; set; }

        /// <summary>
        /// Gets or sets the tokens.
        /// </summary>
        public IEnumerable<EmailToken> Tokens { get; set; }

        /// <summary>
        /// Gets or sets the attachment file paths.
        /// </summary>
        public string[] AttachmentFilePaths { get; set; }
    }
}