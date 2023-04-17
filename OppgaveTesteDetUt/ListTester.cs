using System;
using System.Diagnostics;

namespace OppgaveTesteDetUt
{
    public class ListTester : CollectionTester
    {
        private List<WordDefinition> _list;

        public ListTester(IRepository repository)
            : base(repository)
        {
            _list = new List<WordDefinition>();
        }

        protected override void Add10000()
        {
            foreach (var wordDefinition in _wordDefinitions)
            {
                _list.Add(wordDefinition);
            }
        }

        protected override void Modify1000()
        {
            for (int i = 0; i < 1000; i++)
            {
                _list[i].AddLastAccessTime();
            }
        }

        protected override void Remove1000()
        {
            for (int i = 0; i < 1000; i++)
            {
                _list.Remove(_list[i]);
            }
        }
        public override string ToString()
        {
            return "List: " + base.ToString();
        }
    }
}