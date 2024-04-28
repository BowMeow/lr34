using CodeAnalysis;

namespace ЛР1.Scientific;

public struct State : IState<LexemeType>
{
    public State()
    {
    }

    public LexemeType? CurrentLexemeType { get; private set; } = null;

    private int DotCount { get;  set; } = 0;
    private int StringCount { get; set; } = 0;
    
    public bool IsEnd()
    {
        return this is { CurrentLexemeType: LexemeType.RightParentheses };
    }

    public bool IsBoundaryLexeme(LexemeType lexemeType)
    {
        return this switch
        {
            { CurrentLexemeType: LexemeType.Parameter, DotCount: 0, StringCount: 0 } => lexemeType ==
                                                           LexemeType.AssignmentOperator,
            {CurrentLexemeType: LexemeType.AssignmentOperator, DotCount: 0, StringCount: 0} => lexemeType ==
                                                           LexemeType.LeftBraces,
            { CurrentLexemeType: LexemeType.String, DotCount: 0, StringCount: 0 } => lexemeType ==
                                                           LexemeType.LeftBraces,
            { CurrentLexemeType: LexemeType.LeftBraces, DotCount: 0, StringCount: 1 } => lexemeType ==
                                                           LexemeType.Colon,
            { CurrentLexemeType: LexemeType.Colon, DotCount: 0, StringCount: 1 } => lexemeType ==
                                                           LexemeType.Dot,
            { CurrentLexemeType: LexemeType.Dot, DotCount: 0, StringCount: 1 } => lexemeType ==
                                                           LexemeType.Digit,
            { CurrentLexemeType: LexemeType.Digit, DotCount: 1, StringCount: 1 } => lexemeType ==
                                                           LexemeType.EFormat,
            { CurrentLexemeType: LexemeType.EFormat, DotCount: 1, StringCount: 1 } => lexemeType ==
                                                           LexemeType.RightBraces,
            { CurrentLexemeType: LexemeType.RightBraces, DotCount: 1, StringCount: 1 } => lexemeType ==
                                                           LexemeType.String,
            { CurrentLexemeType: LexemeType.String, DotCount: 1, StringCount: 1 } => lexemeType ==
                                                           LexemeType.Dot,
            { CurrentLexemeType: LexemeType.Dot, DotCount: 1, StringCount: 2 } => lexemeType ==
                                                           LexemeType.Format,
            { CurrentLexemeType: LexemeType.Format, DotCount: 2, StringCount: 2 } => lexemeType ==
                                                           LexemeType.LeftParentheses,
            { CurrentLexemeType: LexemeType.LeftParentheses, DotCount: 2, StringCount: 2 } => lexemeType ==
                                                           LexemeType.Digit,
            { CurrentLexemeType: LexemeType.Digit, DotCount: 3, StringCount: 2 } => lexemeType ==
                                                           LexemeType.RightParentheses,
            _ => false
        };
    }

    public StatesCollection<LexemeType> NextStates()
    {
        return this switch
        {
            { CurrentLexemeType: null, DotCount: 0, StringCount: 0 } =>
                new State { CurrentLexemeType = LexemeType.Parameter, DotCount = 0, StringCount = 0 }
                    .IntoStatesCollection(),

            { CurrentLexemeType: LexemeType.Parameter, DotCount: 0, StringCount: 0 } =>
                new State { CurrentLexemeType = LexemeType.AssignmentOperator, DotCount = 0, StringCount = 0 }
                    .IntoStatesCollection(),

            { CurrentLexemeType: LexemeType.AssignmentOperator, DotCount: 0, StringCount: 0 } =>
                new State { CurrentLexemeType = LexemeType.String, DotCount = 0, StringCount = 0 }
                    .IntoStatesCollection(),

            { CurrentLexemeType: LexemeType.String, DotCount: 0, StringCount: 0 } =>
                new State { CurrentLexemeType = LexemeType.LeftBraces, DotCount = 0, StringCount = 1 }
                    .IntoStatesCollection(),

            { CurrentLexemeType: LexemeType.LeftBraces, DotCount: 0, StringCount: 1 } =>
                new State { CurrentLexemeType = LexemeType.Colon, DotCount = 0, StringCount = 1 }
                    .IntoStatesCollection(),

            { CurrentLexemeType: LexemeType.Colon, DotCount: 0, StringCount: 1 } =>
                new State { CurrentLexemeType = LexemeType.Dot, DotCount = 0, StringCount = 1 }
                    .IntoStatesCollection(),

            { CurrentLexemeType: LexemeType.Dot, DotCount: 0, StringCount: 1 } =>
                new State { CurrentLexemeType = LexemeType.Digit, DotCount = 1, StringCount = 1 }
                    .IntoStatesCollection(),

            { CurrentLexemeType: LexemeType.Digit, DotCount: 1, StringCount: 1 } =>
                new State { CurrentLexemeType = LexemeType.EFormat, DotCount = 1, StringCount = 1 }
                    .IntoStatesCollection(),

            { CurrentLexemeType: LexemeType.EFormat, DotCount: 1, StringCount: 1 } =>
                new State { CurrentLexemeType = LexemeType.RightBraces, StringCount = 1, DotCount = 1 }
                    .IntoStatesCollection(),

            { CurrentLexemeType: LexemeType.RightBraces, DotCount: 1, StringCount: 1 } =>
                new State { CurrentLexemeType = LexemeType.String, DotCount = 1, StringCount = 1 }
                    .IntoStatesCollection(),

            { CurrentLexemeType: LexemeType.String, DotCount: 1, StringCount: 1 } =>
                new State { CurrentLexemeType = LexemeType.Dot, DotCount = 1, StringCount = 2 }
                    .IntoStatesCollection(),

            { CurrentLexemeType: LexemeType.Dot, DotCount: 1, StringCount: 2 } =>
                new State { CurrentLexemeType = LexemeType.Format, DotCount = 2, StringCount = 2 }
                    .IntoStatesCollection(),

            { CurrentLexemeType: LexemeType.Format, DotCount: 2, StringCount: 2 } =>
                new State { CurrentLexemeType = LexemeType.LeftParentheses, DotCount = 2, StringCount = 2 }
                    .IntoStatesCollection(),

            { CurrentLexemeType: LexemeType.LeftParentheses, DotCount: 2, StringCount: 2 } =>
                new State { CurrentLexemeType = LexemeType.Digit, DotCount = 3, StringCount = 2 }
                    .IntoStatesCollection(),

            { CurrentLexemeType: LexemeType.Digit, DotCount: 3, StringCount: 2 } =>
                new State { CurrentLexemeType = LexemeType.RightParentheses, DotCount = 3, StringCount = 2 }
                    .IntoStatesCollection(),
            _ => new StatesCollection<LexemeType>([], -1),
        };
    }
}