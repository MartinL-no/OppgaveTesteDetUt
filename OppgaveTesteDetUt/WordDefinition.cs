namespace OppgaveTesteDetUt
{
    public class WordDefinition : IComparable
    {
        private readonly string _id;
        public readonly string Word;
        public readonly string Definition;
        private TimeSpan _accessTime;

        public WordDefinition(string id, string word, string definition)
        {
            _id = id;
            Word = word;
            Definition = definition;
        }

        public void AddLastAccessTime()
        {
            _accessTime = DateTime.Now.TimeOfDay;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;

            WordDefinition otherWordDefinition = obj as WordDefinition;

            if (otherWordDefinition != null)
            {
                return Word.CompareTo(otherWordDefinition.Word);
            }
            throw new ArgumentException("Object is not a WordDefinition");
        }
    }
}