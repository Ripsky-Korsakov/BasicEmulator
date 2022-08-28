namespace BasicEmulator;

internal class Parser
{
    private readonly SyntaxToken[] _tokens;
    private int _position;

    public Parser(string text)
    {
        _position = 0;
        Lexer lexer = new(text);
        List<SyntaxToken> tokens = new();
        while (true)
        {
            SyntaxToken token = lexer.Lex();

            if (token.Kind == SyntaxKind.EndOfFileToken)
                break;
            
            if (token.Kind != SyntaxKind.WhiteSpaceToken)
                tokens.Add(token);
        }

        _tokens = tokens.ToArray();
    }

    public SyntaxToken[] GetTokens()
    {
        return _tokens;
    }

    private void Next()
    {
        _position++;
    }
    
    private SyntaxToken Peek(int offset)
    {
        if (_position + offset >= _tokens.Length)
            return new SyntaxToken(SyntaxKind.EndOfFileToken, "", null);
        return _tokens[_position + offset];
    }

    /*private SyntaxToken Current => Peek(0);
    
    public SyntaxTree Parse()
    {
        while (true)
        {
            if (Current.Kind == SyntaxKind.EndOfFileToken)
                break;
            
            switch (Current.Kind)
            {
                case SyntaxKind.NumberToken:
                    
            }
        }
    }*/
}

internal class SyntaxTree
{
}

internal class SyntaxNode : SyntaxTree
{
    
}

internal class ExpressionSyntax : SyntaxNode
{
    
}

internal class LiteralExpressionSyntax : ExpressionSyntax
{
    public SyntaxToken Token { get; }
    public Type Type { get; }
    public object? Value => Token.Value;

    public LiteralExpressionSyntax(SyntaxToken token, Type type)
    {
        Token = token;
        Type = type;
    }
}

internal class UnaryExpressionSyntax : ExpressionSyntax
{
    
}

internal class BinaryExpressionSyntax : ExpressionSyntax
{
    
}