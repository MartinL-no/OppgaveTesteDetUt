using System;
using System.Diagnostics;

namespace OppgaveTesteDetUt
{
    public class SortedListTester : CollectionTester
    {
        private SortedList<string, WordDefinition> _sortedList;

        public SortedListTester(IRepository repository)
            : base(repository)
        {
            _sortedList = new SortedList<string, WordDefinition>();
        }

        protected override void Add10000()
        {
            foreach (var wordDefinition in _wordDefinitions)
            {
                if (!_sortedList.ContainsKey(wordDefinition.Word))
                {
                    _sortedList.Add(wordDefinition.Word, wordDefinition);

                }
            }
        }

        protected override void Modify1000()
        {
            foreach (var wordDefinition in _wordDefinitions)
            {
                _sortedList[wordDefinition.Word].AddLastAccessTime();
            }
        }

        protected override void Remove1000()
        {
            foreach (var wordDefinition in _wordDefinitions)
            {
                _sortedList.Remove(wordDefinition.Word);
            }
        }
        public override string ToString()
        {
            return "Sorted List: " + base.ToString();
        }
    }
}