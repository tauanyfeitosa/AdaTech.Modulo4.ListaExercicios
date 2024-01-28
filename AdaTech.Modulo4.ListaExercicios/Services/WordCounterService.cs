using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;
using AdaTech.Modulo4.ListaExercicios.Options;

namespace AdaTech.Modulo4.ListaExercicios.Services
{
    internal class WordCounterService
    {
        private readonly WordCounterOptions _options;

        internal WordCounterService(IOptions<WordCounterOptions> options)
        {
            _options = options.Value;
        }

        internal Dictionary<string, int> CountWords(string input)
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
