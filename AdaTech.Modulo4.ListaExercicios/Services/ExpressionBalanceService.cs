using Microsoft.Extensions.Options;
using AdaTech.Modulo4.ListaExercicios.Options;

namespace AdaTech.Modulo4.ListaExercicios.Services
{
    public class ExpressionBalanceService
    {
        private readonly ExpressionBalanceOptions _options;

        public ExpressionBalanceService(IOptions<ExpressionBalanceOptions> options)
        {
            _options = options.Value;
        }

        public bool IsExpressionBalanced(string expression)
        {
            var stack = new Stack<char>();

            foreach (char c in expression)
            {
                if (_options.CheckParentheses && (c == '(' || c == ')') ||
                    _options.CheckBrackets && (c == '[' || c == ']') ||
                    _options.CheckBraces && (c == '{' || c == '}'))
                {
                    if (c == '(' || c == '[' || c == '{')
                    {
                        stack.Push(c);
                    }
                    else if (c == ')' || c == ']' || c == '}')
                    {
                        if (stack.Count == 0) return false;

                        char opening = stack.Pop();
                        if ((c == ')' && opening != '(') ||
                            (c == ']' && opening != '[') ||
                            (c == '}' && opening != '{'))
                        {
                            return false;
                        }
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}
