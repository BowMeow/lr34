using System;
using CodeAnalysis;

namespace ЛР1.Scientific;

public class LexemeHelper : ILexemeHelper<LexemeType>
{
    public LexemeType UnexpectedSymbol()
    {
        return LexemeType.UnexpectedSymbol;
    }
    
    public bool IsIgnorableLexeme(LexemeType lexeme)
    {
        return lexeme is LexemeType.Separator;
    }
    
    public bool IsInvalidLexeme(LexemeType lexeme)
    {
        return lexeme is LexemeType.UnexpectedSymbol;
    }
    
    public string LexemeMissingValue(LexemeType lexeme)
    {
        return lexeme switch
        {
            LexemeType.Parameter => "id",
            LexemeType.AssignmentOperator => "=",
            LexemeType.Quotes => "\"",
            LexemeType.LeftBraces => "{",
            LexemeType.RightBraces => "}",
            LexemeType.LeftParentheses => "(",
            LexemeType.RightParentheses => ")",
            LexemeType.Colon => ":",
            LexemeType.Dot => ".",
            LexemeType.SecondDot => ".",
            LexemeType.Plus => "+",
            LexemeType.Minus => "-",
            LexemeType.Delimited => ",",
            LexemeType.String => "\"",
            LexemeType.Digit => "1",
            LexemeType.EFormat => "e",
            LexemeType.Format => "format",
            _ => throw new ArgumentException("Invalid LexemeType"),
        };
    }
}