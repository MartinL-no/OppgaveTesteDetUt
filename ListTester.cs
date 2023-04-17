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

        protected override string Add10000()
        {
            _stopWatch.Start();

            foreach (var wordDefinition in _wordDefinitions)
            {
                _list.Add(wordDefinition);
            }

            _stopWatch.Stop();
            var elapsedTime = GetElapsedTime(_stopWatch.Elapsed);
            _stopWatch.Reset();

            return elapsedTime;
        }

        protected override string Modify1000()
        {
            _stopWatch.Start();

            for (int i = 0; i < 1000; i++)
            {
                _list[i].AddLastAccessTime();
            }

            _stopWatch.Stop();
            var elapsedTime = GetElapsedTime(_stopWatch.Elapsed);
            _stopWatch.Reset();

            return elapsedTime;
        }

        protected override string Remove1000()
        {
            _stopWatch.Start();

            for (int i = 0; i < 1000; i++)
            {
                _list.Remove(_list[i]);
            }

            _stopWatch.Stop();
            var elapsedTime = GetElapsedTime(_stopWatch.Elapsed);
            _stopWatch.Reset();

            return elapsedTime;
        }
    }
}