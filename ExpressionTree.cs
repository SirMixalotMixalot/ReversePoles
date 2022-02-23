
namespace ReversePoles;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Text;
public class ExpressionTree {
    ExpressionTree left = null;
    ExpressionTree right = null;
    Token token;

    public int length;


    public ExpressionTree(Token[] tokens) {
        length = tokens.Length;
        var root = tokens.Select((t, i) => (t, i))
                         .Where((tup) => tup.t.isOperator)
                         .OrderBy((tup) => tup.t)
                         .First();
        token = root.t;
        var index = root.i;
        if (index <= 0 || index >= tokens.Length - 1) {
            throw new System.Exception($"Well this sucks. What is {token} doing at {index}?");
        }
        if (index == 1) { // only one thing to our left, hopefully a number!
            left = new ExpressionTree(tokens.First());
        }else {
            left = new ExpressionTree(tokens[0..index]);
        }

        if(index == tokens.Length - 2) { //only one thing to our right
            right = new ExpressionTree(tokens.Last());
        }else {
            right = new ExpressionTree(tokens[(index + 1)..]);
        }
    }
    public ExpressionTree(Token t) {
        if (t.kind != TokenKind.Number) {
            throw new System.Exception("Bruh!");
        }
        token = t;
    }

    public List<Token> PostOrderTraversal() {
        var list = new List<Token>(length);
        if (left != null)
            list.AddRange(left.PostOrderTraversal());
        if (right != null)
            list.AddRange(right.PostOrderTraversal());
        list.Add(token);

        return list;

    }
}