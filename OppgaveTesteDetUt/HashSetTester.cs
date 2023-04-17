using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace OppgaveTesteDetUt
{
    public class HashSetTester : CollectionTester
    {
        private HashSet<WordDefinition> _hashset;

        public HashSetTester(IRepository repository)
            : base(repository)
        {
            _hashset = new HashSet<WordDefinition>();
        }

        protected override void Add10000()
        {
            foreach (var wordDefinition in _wordDefinitions)
            {
                _hashset.Add(wordDefinition);
            }
        }

        protected override void Modify1000()
        {
            var counter = 0;
            foreach (var definition in _hashset)
            {
                definition.AddLastAccessTime();
                counter++;
                if (counter == 1000) break;
            }
        }

        protected override void Remove1000()
        {
            var counter = 0;
            foreach (var definition in _hashset)
            {
                _hashset.Remove(definition);
                counter++;
                if (counter == 1000) break;
            }
        }
        public override string ToString()
        {
            return "Hashset: " + base.ToString();
        }
    }
}