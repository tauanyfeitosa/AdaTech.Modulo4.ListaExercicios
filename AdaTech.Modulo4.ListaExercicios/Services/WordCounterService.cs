using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;
using AdaTech.Modulo4.ListaExercicios.Options;

namespace AdaTech.Modulo4.ListaExercicios.Services
{
    public class WordCounterService
    {
        private readonly WordCounterOptions _options;

        public WordCounterService(IOptions<WordCounterOptions> options)
        {
            _options = options.Value;
        }

        public Dictionary<string, int> CountWords(string input)
        {
            var wordCount = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
            var wordPattern = @"\w+";
            foreach (Match match in Regex.Matches(input, wordPattern))
            {
                string word = _options.IgnoreCase ? match.Value.ToLowerInvariant() : match.Value;

                if (!wordCount.ContainsKey(word))
                {
                    wordCount[word] = 0;
                }
                wordCount[word]++;
            }
            return wordCount;
        }
    }
}
