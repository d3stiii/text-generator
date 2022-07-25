using System.Text;

namespace TextGenerator;

public class TextParser {
    public List<List<string>> ParseSentences(string text) {
        var sentences = text.Split(new[] { '.', '!', '?', ';', ':', '(', ')' },
            StringSplitOptions.RemoveEmptyEntries);

        return sentences.Select(GetWords).Where(words => words.Capacity > 0)
            .ToList();
    }

    private List<string> GetWords(string sentence) {
        var builder = new StringBuilder();
        foreach (var letter in sentence) 
            builder.Append(letter);

        var words = builder.ToString().ToLower().Split(' ');
        return words.Where(word => !string.IsNullOrWhiteSpace(word)).ToList();
    }
}