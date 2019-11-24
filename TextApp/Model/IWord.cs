namespace TextApp.Model
{
    interface IWord:ISentenceItem
    {
        Symbol[] Symbols { get; }
        Symbol[] this[int index] { get; }
        int Length { get; }
        int LineNumber { get; }
        bool IsConsonant { get; }
    }
}