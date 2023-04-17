using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace OppgaveTesteDetUt
{
    public class SortedSetTester : CollectionTester
    {
        private SortedSet<WordDefinition> _sortedSet;

        public SortedSetTester(IRepository repository)
            : base(repository)
        {
            _sortedSet = new SortedSet<WordDefinition>();
        }

        protected override void Add10000()
        {
            foreach (var wordDefinition in _wordDefinitions)
            {
                _sortedSet.Add(wordDefinition);
            }
        }

        protected override void Modify1000()
        {
            var counter = 0;

            foreach (var definition in _sortedSet)
            {
                definition.AddLastAccessTime();
                counter++;
                if (counter == 1000) break;
            }
        }

        protected override void Remove1000()
        {
            var counter = 0;
            var setToRemove = new SortedSet<WordDefinition>();
            foreach (var wordDefinition in _sortedSet)
            {
                setToRemove.Add(wordDefinition);
                counter++;
                if (counter == 1000) break;
            }
            _sortedSet.ExceptWith(setToRemove);
        }
        public override string ToString()
        {
            return "SortedSet: " + base.ToString();
        }
    }
}