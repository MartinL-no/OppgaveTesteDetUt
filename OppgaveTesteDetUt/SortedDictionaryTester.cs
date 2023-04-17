using System;
using System.Diagnostics;

namespace OppgaveTesteDetUt
{
    public class SortedDictionaryTester : CollectionTester
    {
        private SortedDictionary<string, WordDefinition> _sortedDictionary;

        public SortedDictionaryTester(IRepository repository)
            : base(repository)
        {
            _sortedDictionary = new SortedDictionary<string, WordDefinition>();
        }

        protected override void Add10000()
        {
            foreach (var wordDefinition in _wordDefinitions)
            {
                if (!_sortedDictionary.ContainsKey(wordDefinition.Word))
                {
                    _sortedDictionary.Add(wordDefinition.Word, wordDefinition);

                }
            }
        }

        protected override void Modify1000()
        {
            foreach (var wordDefinition in _wordDefinitions)
            {
                _sortedDictionary[wordDefinition.Word].AddLastAccessTime();
            }
        }

        protected override void Remove1000()
        {
            foreach (var wordDefinition in _wordDefinitions)
            {
                _sortedDictionary.Remove(wordDefinition.Word);
            }
        }
        public override string ToString()
        {
            return "Sorted Dictionary: " + base.ToString();
        }
    }
}