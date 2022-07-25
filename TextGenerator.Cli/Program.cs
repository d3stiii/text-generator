namespace TextGenerator.Cli;

public static class Program {
    public static void Main(string[] args) {
        Console.WriteLine("Welcome to the text generator.");

        var parser = new TextParser();
        var frequencyAnalysis = new FrequencyAnalysis();
        var textGenerator = new TextGenerator();

        Console.Write("Write the path to the text file: ");
        var text = File.ReadAllText(Console.ReadLine()!);
        var sentences = parser.ParseSentences(text);

        const int wordsCount = 50;
        var frequency = frequencyAnalysis.GetMostFrequentNextWords(sentences);
        while (true) {
            Console.Write("Write the beginning of the phrase: ");
            var beginning = Console.ReadLine();
            if (string.IsNullOrEmpty(beginning)) return;
            var phrase = textGenerator.ContinuePhrase(frequency, beginning.ToLower(), wordsCount);
            Console.WriteLine(phrase);
        }
    }
}