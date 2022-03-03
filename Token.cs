using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ReversePoles;

public class Token : IComparable<Token>
{
    public int precedence;
    string token;
    public TokenKind kind;

    public bool isOperator = false;


    public Token(int p, char t, TokenKind k)
    {
        precedence = p; 
        token = t.ToString();
        kind = k;
        isOperator = k != TokenKind.Number;
    }
    public Token(int p, string t, TokenKind k)
    {
        precedence=p;
        token = t;
        kind = k;
        isOperator = k != TokenKind.Number;

    }

    public int CompareTo([AllowNull] Token other)
    {
        return precedence - other.precedence;
    }
    public override string ToString() => token;
}
public static class Utilities {
    public static Dictionary<char, Token> Tokens = new()
    {
        { '+', new Token(2,'+',TokenKind.Add) },
        { '-', new Token(2,'-',TokenKind.Sub) },
        { '*', new Token(4,'*',TokenKind.Mul) },
        { '/', new Token(4,'/',TokenKind.Div) },
        { '^', new Token(4,'^',TokenKind.Exponent)}
    };
    public static Token TokenFromNumber(string n) => new(0, n, TokenKind.Number);

}

