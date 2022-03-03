using System.Collections.Generic;
using System.Linq;
using System;
namespace ReversePoles
{
    public static class Poles
    {
        static List<Token> TokenizeParens(string expression) {
            int parenLevel = 0;
            var tokens = new List<Token>();
            foreach(string s in expression.Trim().Split(" ")) {
                if (s == "(" || s == ")") {
                    parenLevel += s == ")" ? 1: -1;
                    continue;
                }
                var token = Utilities.Tokens.GetValueOrDefault(s[0], Utilities.TokenFromNumber(s));
                token.precedence += 2 * parenLevel;
                tokens.Add(token);
            }
            return tokens;

        }

        static IEnumerable<Token> Tokenize(string expression)
        {
            return expression.Trim()
                .Split(' ')
                .Select(x => Utilities.Tokens.GetValueOrDefault(x[0], Utilities.TokenFromNumber(x)));
        }

        public static void Main()
        {
            const string expression = "(5 + 4)/(2 - 1)";
            var tokens = TokenizeParens(expression).ToArray();
            var tree = new ExpressionTree(tokens);

            foreach(var token in tree.PostOrderTraversal()) {
                Console.WriteLine(token);
            }
        }
    }
   

    
        
}