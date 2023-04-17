using System;
using System.Diagnostics;

namespace OppgaveTesteDetUt
{
    public class DictionaryTester : CollectionTester
    {
        private Dictionary<string, WordDefinition> _dictionary;

        public DictionaryTester(IRepository repository)
            : base(repository)
        {
            _dictionary = new Dictionary<string, WordDefinition>();
        }

        protected override void Add10000()
        {
            foreach (var wordDefinition in _wordDefinitions)
            {
                if (!_dictionary.ContainsKey(wordDefinition.Word))
                {
                    _dictionary.Add(wordDefinition.Word, wordDefinition);

                }
            }
        }

        protected override void Modify1000()
        {
            foreach (var wordDefinition in _wordDefinitions)
            {
                _dictionary[wordDefinition.Word].AddLastAccessTime();
            }
        }

        protected override void Remove1000()
        {
            foreach (var wordDefinition in _wordDefinitions)
            {
                _dictionary.Remove(wordDefinition.Word);
            }
        }
        public override string ToString()
        {
            return "Dictionary: " + base.ToString();
        }
    }
}