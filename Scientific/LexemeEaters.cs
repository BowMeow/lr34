using CodeAnalysis;

namespace ЛР1.Scientific;

public static class LexemeEaters
{
    public static LexemeEater<LexemeType>[] Eaters =
    [
        TryEatEFormat,
        TryEatFormat,
        TryEatIdentifier,
        TryEatEqual,
        TryEatString,
        TryEatLeftBraces,
        TryEatColon,
        TryEatDot,
        TryEatNumber,
        TryEatNumberWithoutDot,
        TryEatSeparator,
        TryEatRightBrace,
        TryEatPlus,
        TryEatMinus,
        TryEatDelimited,
        TryEatLeftParentheses,
        TryEatRightParentheses,
    ];

    

    private static LexemeType? TryEatIdentifier(Eater eater)
    {
        if (!eater.Eat(IsIdentifierHead)) return null;
        eater.EatWhile(IsIdentifierHead);

        return LexemeType.Parameter;
    }
    
    private static bool IsEqualAfterId(char sym)
    {
        return sym == '=';
    }
    private static bool IsIdentifierHead(char sym)
    {
        return (char.IsLetter(sym) || sym == '_');
    }
    
    private static bool IsIdentifierTail(char sym)
    {
        return char.IsLetterOrDigit(sym) || sym == '_';
    }

    private static LexemeType? TryEatEqual(Eater eater)
    {
        return eater.Eat("=")
            ? LexemeType.AssignmentOperator
            : null;
    }

    private static LexemeType? TryEatString(Eater eater)
    {
        return eater.Eat("\"")
            ? LexemeType.String
            : null;
    }

    private static LexemeType? TryEatLeftBraces(Eater eater)
    {
        return eater.Eat("{")
            ? LexemeType.LeftBraces
            : null;
    }

    private static LexemeType? TryEatColon(Eater eater)
    {
        return eater.Eat(":")
            ? LexemeType.Colon
            : null;
    }

    private static LexemeType? TryEatDot(Eater eater)
    {
        return eater.Eat(".")
            ? LexemeType.Dot
            : null;
    }

    private static LexemeType? TryEatDigit(Eater eater)
    {
        return eater.EatWhile(IsDigit)
            ? LexemeType.Digit
            : null;
    }

    private static bool IsDigit(char c)
    {
        return char.IsDigit(c);
    }
    
    private static LexemeType? TryEatSeparator(Eater eater)
    {
        return eater.EatWhile(IsSeparator) ? LexemeType.Separator : null;
    }
    
    private static bool IsSeparator(char sym, char? nextSym)
    {
        return char.IsSeparator(sym)
               || sym == '\n'  
               || (nextSym is { } n && (sym == '\r' && n == '\n'));
    }

    private static LexemeType? TryEatNumber(Eater eater)
    {
        if (!eater.EatWhile(IsDigit)) return null;
        if (eater.Eat(".")) return eater.EatWhile(IsDigit) ? LexemeType.Digit : LexemeType.Digit;
        return null;
    }
    
    private static LexemeType? TryEatNumberWithoutDot(Eater eater)
    {
        if (eater.EatWhile(IsDigit)) return LexemeType.Digit;
        return null;
    }
    
    private static LexemeType? TryEatEFormat(Eater eater)
    {
        return eater.Eat("e")
            ? LexemeType.EFormat
            : null;
    }

    private static LexemeType? TryEatRightBrace(Eater eater)
    {
        return eater.Eat("}")
            ? LexemeType.RightBraces
            : null;
    }

    private static LexemeType? TryEatFormat(Eater eater)
    {
        return eater.Eat("format")
            ? LexemeType.Format
            : null;
    }
    
    private static LexemeType? TryEatPlus(Eater eater)
    {
        return eater.Eat("+")
            ? LexemeType.Plus
            : null;
    }
    
    private static LexemeType? TryEatMinus(Eater eater)
    {
        return eater.Eat("-")
            ? LexemeType.Minus
            : null;
    }
    
    private static LexemeType? TryEatDelimited(Eater eater)
    {
        return eater.Eat(",")
            ? LexemeType.Delimited
            : null;
    }
    
    private static LexemeType? TryEatLeftParentheses(Eater eater)
    {
        return eater.Eat("(")
            ? LexemeType.LeftParentheses
            : null;
    }
    
    private static LexemeType? TryEatRightParentheses(Eater eater)
    {
        return eater.Eat(")")
            ? LexemeType.RightParentheses
            : null;
    }
}