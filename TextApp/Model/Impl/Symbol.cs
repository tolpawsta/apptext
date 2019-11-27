namespace TextApp.Model
{
    struct Symbol
    {
       public string Chars { get; }

        
        public Symbol(string symbols)
        {
            Chars = symbols;
        }

        public Symbol(char symbol)
        {
            Chars = symbol.ToString();
        }
    }
}