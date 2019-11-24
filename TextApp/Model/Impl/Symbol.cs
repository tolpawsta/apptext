namespace TextApp.Model
{
    struct Symbol
    {
        string Symbols { get; }

        public Symbol(string symbols)
        {
            Symbols = symbols;
        }

        public Symbol(char symbol)
        {
            Symbols = $"{symbol}";
        }
    }
}