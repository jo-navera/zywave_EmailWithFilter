using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZywaveApi.Entities;
using ZywaveApi.Services;

namespace ZywaveApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost]
        public EmailResponse SendEmail(string? from, string? to, string? subject, string? message)
        {
           return _emailService.SendEmail(to, from, subject, message).Result;
        }
    }
}
