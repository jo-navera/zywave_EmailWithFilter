using System.Net.Mail;
using ZywaveApi.Entities;

namespace ZywaveApi.Services
{
    public interface IEmailService
    {
        public Task<EmailResponse> SendEmail(string? from, string? to, string? subject, string? body);
    }
    public class EmailService : IEmailService
    {
        private readonly ITextFilterService _textFilterService;
        public EmailService(ITextFilterService textFilterService)
        {
            _textFilterService = textFilterService;
        }
        public async Task<EmailResponse> SendEmail(string? from, string? to, string? subject, string? body)
        {

            if (string.IsNullOrEmpty(from)) { throw new ArgumentNullException(nameof(from), Constants.EmptyEmailFromExceptionMessage); }
            if (string.IsNullOrEmpty(to)) { throw new ArgumentNullException(nameof(to), Constants.EmptyEmailToExceptionMessage); }
            if (string.IsNullOrEmpty(subject)) { throw new ArgumentNullException(nameof(from), Constants.EmptyEmailSubjectExceptionMessage);  }
            if (string.IsNullOrEmpty(body)) { throw new ArgumentNullException(nameof(from), Constants.EmptyEmailSubjectExceptionMessage); }

            var filterResult = new TextFilterResponse();
            var sendResult = false;
            using (MailMessage emailMessage = new MailMessage())
            {
                emailMessage.From = new MailAddress(from);
                emailMessage.To.Add(new MailAddress(to));
                emailMessage.Subject = subject;

                //Use below if filtering is not needed
                //emailMessage.Body = body;

                //Filter message body before sending
                filterResult = await _textFilterService.FilterText(null, body);
                emailMessage.Body = filterResult.ResultText;

                emailMessage.Priority = MailPriority.Normal;

                //Settings and credentials are just samples and aren't expected to work
                //using (SmtpClient MailClient = new SmtpClient("smtp.gmail.com", 111))
                //{
                //    MailClient.EnableSsl = true;
                //    MailClient.Credentials = new System.Net.NetworkCredential("account@gmail.com", "password");
                //    MailClient.Send(emailMessage);
                //}
                sendResult = true;
            }

            return new EmailResponse() { FilterResponse = filterResult, IsSuccess = sendResult };
        }
    }
}
