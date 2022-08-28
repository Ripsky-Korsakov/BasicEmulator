namespace BasicEmulator;

internal class Lexer
{
    private readonly string _text;
    private int _position;

    public Lexer(string text)
    {
        _text = text;
        _position = 0;
    }

    private void Next()
    {
        _position++;
    }

    private char NextCharacter()
    {
        char c = Current;
        Next();
        return c;
    }

    private char Current
    {
        get
        {
            if (_position >= _text.Length)
                return '\0';
            return _text[_position];
        }
    }

    public SyntaxToken Lex()
    {
        if (Current == '\0')
        {
            return new SyntaxToken(SyntaxKind.EndOfFileToken, "\0", null);
        }

        if (char.IsWhiteSpace(Current))
        {
            int start = _position;
            while (char.IsWhiteSpace(Current))
            {
                Next();
            }
            return new SyntaxToken(SyntaxKind.WhiteSpaceToken, " ", null);
        }

        if (char.IsDigit(Current))
        {
            int start = _position;
            while (char.IsDigit(Current))
            {
                Next();
            }

            int length = _position - start;
            string text = _text.Substring(start, length);
            if (int.TryParse(text, out int value))
            {
                return new SyntaxToken(SyntaxKind.NumberToken, text, value);
            }
            return new SyntaxToken(SyntaxKind.BadToken,"", null);
        }

        switch (Current)
        {
            case '+':
                return SingleCharacterToken(SyntaxKind.PlusToken);
            case '-':
                return SingleCharacterToken(SyntaxKind.MinusToken);
            case '*':
                return SingleCharacterToken(SyntaxKind.StarToken);
            case '/':
                return SingleCharacterToken(SyntaxKind.SlashToken);
            case '(':
                return SingleCharacterToken(SyntaxKind.OpenParenthesisToken);
            case ')':
                return SingleCharacterToken(SyntaxKind.CloseParenthesisToken);
        }

        return new SyntaxToken(SyntaxKind.BadToken, NextCharacter().ToString(), null);
    }

    private SyntaxToken SingleCharacterToken(SyntaxKind kind)
    {
        return new SyntaxToken(kind, NextCharacter().ToString(), null);
    }
}