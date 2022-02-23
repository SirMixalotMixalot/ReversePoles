using System.Collections.Generic;
using System.Linq;
using System;
namespace ReversePoles
{
    public static class Poles
    {
        static IEnumerable<Token> Tokenize(string expression)
        {
            return expression.Trim()
                .Split(' ')
                .Select(x => Utilities.Tokens.GetValueOrDefault(x[0], Utilities.TokenFromNumber(x)));
        }

        public static void Main()
        {
            const string expression = "5 + 5 - 6 * 2";
            var tokens = Tokenize(expression).ToArray();
            var tree = new ExpressionTree(tokens);

            foreach(var token in tree.PostOrderTraversal()) {
                Console.WriteLine(token);
            }
        }
    }
   

    
        
}