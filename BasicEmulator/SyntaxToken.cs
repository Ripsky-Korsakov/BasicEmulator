namespace BasicEmulator;

internal class SyntaxToken
{
    public SyntaxKind Kind { get; }
    public string Text { get; }
    public object? Value { get; }

    public SyntaxToken(SyntaxKind kind, string text, object? value)
    {
        Kind = kind;
        Text = text;
        Value = value;
    }
}