using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZywaveApi.Entities;
using ZywaveApi.Services;

namespace ZywaveApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextFilterController : ControllerBase
    {
        private readonly ITextFilterService _textFilterService;
        public TextFilterController(ITextFilterService textFilterService) { 
            _textFilterService = textFilterService;
        }
        [HttpPost]
        public TextFilterResponse CensorText(List<string>? censorWords, string? inputText) { 
           return _textFilterService.FilterText(censorWords, inputText).Result; 
        }
    }
}
