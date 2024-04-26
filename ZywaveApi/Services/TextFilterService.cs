using System.Text.RegularExpressions;
using ZywaveApi.Entities;

namespace ZywaveApi.Services
{
    public interface ITextFilterService
    {
        Task<TextFilterResponse> FilterText(List<string>? censorWords, string? text);
    }
    public class TextFilterService : ITextFilterService
    {
        public Task<TextFilterResponse> FilterText(List<string>? censorWords, string? text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("Input text should not be empty.");
            }

            censorWords ??= Constants.CensorWords;
            if (censorWords.Count == 0)
            {
                censorWords = Constants.CensorWords;
            }
            var result = new TextFilterResponse() { Filtered = false, ResultText = text };

            foreach (var censorWord in censorWords)
            {
                result.ResultText = Regex.Replace(result.ResultText, censorWord, Constants.CensorReplace, RegexOptions.IgnoreCase);
                result.Filtered = true;
            }

            return Task.FromResult(result);
        }


    }
}
