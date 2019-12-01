using TextApp.Model.Enum;

namespace TextApp.Model
{
    interface IWord : ISentenceItem
    {
        int Length { get; }
        int LineNumber { get; set; }
        InitialSymbolType InitialSymbol(string[] vowels);
    }
}