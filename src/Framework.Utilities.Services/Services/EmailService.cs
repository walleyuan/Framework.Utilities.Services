// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailService.cs" company="ZHEN YUAN">
//   Copyright (c) ZHEN All rights reserved.
// </copyright>
// <summary>
//   Defines the EmailService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace Framework.Utilities.Services.Services
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Mail;
    using System.Net.Mime;

    using Framework.Utilities.Services.Models;

    /// <summary>
    /// The email service.
    /// </summary>
    public class EmailService
    {
        /// <summary>
        /// The send plain text email.
        /// </summary>
        /// <param name="emailMessage">
        /// The email message.
        /// </param>
        public static void SendEmailMessage(EmailMessage emailMessage)
        {
            var mailMessage = GetEmailMessage(
                 from: emailMessage.From,
                 fromName: emailMessage.FromName,
                 recipients: emailMessage.To,
                 bccRecipients: emailMessage.Bcc,
                 subject: emailMessage.Subject,
                 body: emailMessage.Body,
                 isHtml: emailMessage.IsHtml,
                 tokens: emailMessage.Tokens,
                 attachmentFilePaths: emailMessage.AttachmentFilePaths);

            SendEmail(mailMessage);
        }

        /// <summary>
        /// The send email.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        private static void SendEmail(MailMessage email)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.Send(email);
            }
        }

        /// <summary>
        /// The get email message.
        /// </summary>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <param name="fromName">
        /// The from name.
        /// </param>
        /// <param name="recipients">
        /// The recipients.
        /// </param>
        /// <param name="bccRecipients">
        /// The bcc recipients.
        /// </param>
        /// <param name="subject">
        /// The subject.
        /// </param>
        /// <param name="body">
        /// The body.
        /// </param>
        /// <param name="isHtml">
        /// The is html.
        /// </param>
        /// <param name="tokens">
        /// The tokens.
        /// </param>
        /// <param name="attachmentFilePaths">
        /// The attachment file paths.
        /// </param>
        /// <returns>
        /// The <see cref="MailMessage"/>.
        /// </returns>
        private static MailMessage GetEmailMessage(
            string from,
            string fromName,
            string recipients,
            string bccRecipients,
            string subject,
            string body,
            bool isHtml,
            IEnumerable<EmailToken> tokens = null,
            string[] attachmentFilePaths = null)
        {
            if (tokens != null)
            {
                body = tokens.Aggregate(body, (current, token) => current.Replace(token.Key, token.Value));
            }

            MailMessage email = new MailMessage
            {
                From =
                                            string.IsNullOrEmpty(fromName)
                                                ? new MailAddress(from)
                                                : new MailAddress(from, fromName),
                Subject = subject,
                Body = body,
                IsBodyHtml = isHtml
            };

            foreach (var ad in recipients.Split(';').Where(x => !string.IsNullOrEmpty(x)))
            {
                email.To.Add(new MailAddress(ad));
            }

            AddBccs(bccRecipients, email);
            AddAttachments(attachmentFilePaths, email);

            return email;
        }

        /// <summary>
        /// The add bcc.
        /// </summary>
        /// <param name="bccRecipients">
        /// The bcc recipients.
        /// </param>
        /// <param name="email">
        /// The email.
        /// </param>
        private static void AddBccs(string bccRecipients, MailMessage email)
        {
            if (!string.IsNullOrWhiteSpace(bccRecipients))
            {
                email.Bcc.Add(bccRecipients);
            }
        }

        /// <summary>
        /// The add attachments.
        /// </summary>
        /// <param name="attachmentFilePaths">
        /// The attachment file paths.
        /// </param>
        /// <param name="email">
        /// The email.
        /// </param>
        private static void AddAttachments(string[] attachmentFilePaths, MailMessage email)
        {
            if (attachmentFilePaths != null && attachmentFilePaths.Length > 0)
            {
                foreach (string filePath in attachmentFilePaths)
                {
                    if (string.IsNullOrEmpty(filePath))
                    {
                        continue;
                    }

                    string mediaType = MediaTypeNames.Application.Octet;

                    string extension = Path.GetExtension(filePath);

                    if (!string.IsNullOrEmpty(extension) && extension.Equals(".pdf", StringComparison.InvariantCultureIgnoreCase))
                    {
                        mediaType = MediaTypeNames.Application.Pdf;
                    }

                    email.Attachments.Add(new Attachment(filePath, mediaType));
                }
            }
        }
    }
}