using System.IO;

namespace OppgaveTesteDetUt;
class Program
{
    static void Main(string[] args)
    {
        var wordListRepository = new WordListRepository(@"../../../ordliste.txt");

        var listTester = new ListTester(wordListRepository);
        var hashSetTester = new HashSetTester(wordListRepository);
        var sortedSetTester = new SortedSetTester(wordListRepository);
        var linkedListTester = new LinkedListTester(wordListRepository);
        var sortedListTester = new SortedListTester(wordListRepository);
        var dictionaryTester = new DictionaryTester(wordListRepository);
        var sortedDictionaryTester = new SortedDictionaryTester(wordListRepository);

        Console.WriteLine(listTester);
        Console.WriteLine(hashSetTester);
        Console.WriteLine(sortedSetTester);
        Console.WriteLine(linkedListTester);
        Console.WriteLine(sortedListTester);
        Console.WriteLine(dictionaryTester);
        Console.WriteLine(sortedDictionaryTester);
    }
}