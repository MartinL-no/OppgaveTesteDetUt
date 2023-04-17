using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace OppgaveTesteDetUt
{
    public class LinkedListTester : CollectionTester
    {
        private LinkedList<WordDefinition> _linkedList;

        public LinkedListTester(IRepository repository)
            : base(repository)
        {
            _linkedList = new LinkedList<WordDefinition>();
        }

        protected override void Add10000()
        {
            _linkedList.AddFirst(_wordDefinitions[0]);
            for (int i = 1; i < _wordDefinitions.Length; i++)
            {
                _linkedList.AddLast(_wordDefinitions[i]);
            }
        }

        protected override void Modify1000()
        {
            var counter = 0;
            foreach (var definition in _linkedList)
            {
                definition.AddLastAccessTime();
                counter++;
                if (counter == 1000) break;
            }
        }

        protected override void Remove1000()
        {
            for (int i = 0; i < 1000; i++)
            {
                _linkedList.RemoveFirst();
            }
        }
        protected void Remove1000AtEnd()
        {
            for (int i = 0; i < 1000; i++)
            {
                _linkedList.RemoveLast();
            }
        }
        public override string ToString()
        {
            return $"LinkedList: {base.ToString()}, removing 1000 objects at end: {Timer(Remove1000AtEnd)} micro/s";
        }
    }
}