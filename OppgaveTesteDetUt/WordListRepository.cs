using System;
namespace OppgaveTesteDetUt
{
    public class WordListRepository : IRepository
    {
        private string _filepath;
        private WordDefinition[] _wordDefinitions;

        public WordListRepository(string filepath)
        {
            _filepath = filepath;
            _wordDefinitions = new WordDefinition[1000000];

        }

        public WordDefinition[] GetWordDefinitions()
        {

            if (_wordDefinitions[0] != null) return _wordDefinitions;

            using (StreamReader sr = File.OpenText(_filepath))
            {
                for (int i = 0; i < 1000000; i++)
                {
                    var line = sr.ReadLine();
                    var lineElements = line.Split("\t");
                    var id = lineElements[0];
                    var word = lineElements[1];
                    var definition = lineElements[2];

                    _wordDefinitions[i] = new WordDefinition(id, word, definition);
                }
            }
            return _wordDefinitions;
        }
    }
}

