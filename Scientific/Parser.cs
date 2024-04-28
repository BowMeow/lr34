using CodeAnalysis;

namespace ЛР1.Scientific;

public class Parser() : Parser<LexemeType, State>(new LexemeHelper(), LexemeEaters.Eaters);
