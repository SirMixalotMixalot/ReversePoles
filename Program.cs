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
            var i = 0;
            foreach(char c in expression.Trim()) {
                var isParen = c == '(' || c == ')';
                if(c == ' ' || isParen ) {
                    if (isParen) 
                        parenLevel += c == '(' ? 1: -1;
                    i += 1;
                    continue;
                }

                var space = i;
                while(space < expression.Length && Char.IsNumber(expression[space])) {
                    space += 1;
                }
                string s = space == i? c.ToString() : expression.Substring(i,space - i);
                var token = Utilities.Tokens.GetValueOrDefault(s[0], Utilities.TokenFromNumber(s));
                token.precedence += 3 * parenLevel;
                tokens.Add(token);
                i += 1;
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
            const string expression = "(2/1)*4/(5-3)";
            var tokens = TokenizeParens(expression).ToArray();
            var tree = new ExpressionTree(tokens);

            foreach(var token in tree.PostOrderTraversal()) {
                Console.Write(token);
                Console.Write(" ");
            }
            Console.WriteLine("= " + tree.Eval() );
        }
    }
   

    
        
}