using System.Diagnostics;

namespace OppgaveTesteDetUt
{
    public abstract class CollectionTester
    {
        protected WordDefinition[] _wordDefinitions;
        protected Stopwatch _stopWatch;

        protected CollectionTester(IRepository repository)
        {
            _wordDefinitions = repository.GetWordDefinitions();
            _stopWatch = new Stopwatch();
        }

        protected abstract void Add10000();

        protected abstract void Modify1000();

        protected abstract void Remove1000();

        protected string GetElapsedTime(TimeSpan timeSpan)
        {
            return timeSpan.Microseconds.ToString();
        }

        public delegate void FunctionType();

        protected string Timer(FunctionType predicate)
        {
            _stopWatch.Start();

            predicate();

            _stopWatch.Stop();
            var elapsedTime = GetElapsedTime(_stopWatch.Elapsed);
            _stopWatch.Reset();

            return elapsedTime;
        }
        public override string ToString()
        {
            return $"adding 10,000 objects: {Timer(Add10000)} micro/s, modifying 1000 objects: {Timer(Modify1000)} micro/s, removing 1000 objects: {Timer(Remove1000)} micro/s";
        }
    }
}