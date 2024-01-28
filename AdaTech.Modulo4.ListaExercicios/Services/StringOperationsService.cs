using System.Collections.Generic;
using Microsoft.Extensions.Options;
using AdaTech.Modulo4.ListaExercicios.Options;

namespace AdaTech.Modulo4.ListaExercicios.Services
{
    public class StringOperationsService
    {
        private readonly int _minLength;

        public StringOperationsService(IOptions<StringFilterOptions> options)
        {
            _minLength = options.Value.MinLength;
        }

        public List<string> FilterList(List<string> input)
        {
            var result = new List<string>();
            foreach (var str in input)
            {
                if (str.Length >= _minLength)
                {
                    result.Add(str);
                }
            }
            return result;
        }
    }
}
