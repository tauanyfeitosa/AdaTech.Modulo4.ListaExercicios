using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;
using AdaTech.Modulo4.ListaExercicios.Options;
using BenchmarkDotNet.Attributes;

namespace AdaTech.Modulo4.ListaExercicios.Services
{
    public class WordCounterService
    {
        private readonly WordCounterOptions _options;

        // O pacote de benchmark não estão considerando a injeção de dependência,
        // portanto adicionei um construtor padrão para fins de benchmark somente
        public WordCounterService()
        {
            _options = new WordCounterOptions();
        }

        public WordCounterService(IOptions<WordCounterOptions> options)
        {
            _options = options.Value;
        }

        public Dictionary<string, int> CountWords(string input)
        {
            // Usar aqui o StringComparer.InvariantCultureIgnoreCase vai fazer a sua option ser
            // desconsiderada, pois a condição a seguir que transforma a string em minúsculas vai
            // ser indiferente se o comparador já ignora o case xP
            var wordCount = new Dictionary<string, int>();
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

        public Dictionary<string, int> CountWords2(string input)
        {
            var wordCount = new Dictionary<string, int>();
            var words = input.Split(' ', '.', ',', '!', '?', ':', ';', '-');
            foreach (var word in words)
            {
                string normalizedWord = _options.IgnoreCase ? word.ToLowerInvariant() : word;

                if (!wordCount.ContainsKey(normalizedWord))
                {
                    wordCount[normalizedWord] = 0;
                }
                wordCount[normalizedWord]++;
            }
            return wordCount;
        }

        const string benchmarkText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla auctor porta velit a tincidunt. Nam efficitur iaculis placerat. Aenean lectus dui, sollicitudin id rhoncus tristique, aliquet sed quam. Phasellus blandit magna at elementum consequat. Nam vitae nunc vehicula, blandit felis a, placerat augue. Quisque bibendum a ipsum at scelerisque. Duis molestie turpis quis orci vehicula aliquam. Duis non elementum erat. Phasellus et dui odio. Nunc vitae leo sem. Curabitur nec enim id mi aliquet commodo at et sapien. Fusce sit amet nisi elit. Interdum et malesuada fames ac ante ipsum primis in faucibus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Duis vitae dolor at sem ultrices euismod. Morbi aliquet, felis et mattis congue, justo nunc pharetra lectus, a lobortis mauris eros et nulla. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Maecenas sollicitudin posuere nibh malesuada suscipit. Nam a sapien ex. Donec mollis justo est, quis tempus mi pharetra at. Cras fringilla enim eu egestas scelerisque. Praesent tristique imperdiet consectetur. Donec interdum pulvinar nulla vel pharetra. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Aliquam interdum finibus mi, in tempus lorem. Cras diam magna, viverra vitae ante eget, scelerisque sodales velit. Aliquam erat volutpat. Mauris consectetur sapien mi, vel euismod quam consectetur id.";

        [Benchmark(Description = "Using regex")]
        public void BenchmarkRegex()
        {
            CountWords(benchmarkText);
        }

        [Benchmark(Description = "Using splitters only")]
        public void BenchmarkSplit()
        {
            CountWords2(benchmarkText);
        }
    }
}
