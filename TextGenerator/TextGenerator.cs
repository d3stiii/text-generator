using System.Text;

namespace TextGenerator;

public class TextGenerator {
    public string ContinuePhrase(Dictionary<string, string> nextWords, string phraseBeginning,
        int wordsCount) {
        StringBuilder builder = new StringBuilder();
        builder.Append($"{phraseBeginning}");

        for (int i = 0; i < wordsCount; i++) {
            string[] words = builder.ToString().Split(' ');
            string lastWord = words[^1];

            if (words.Length >= 2) {
                string twoLastWords = $"{words[^2]} {words[^1]}";

                if (nextWords.ContainsKey(twoLastWords)) {
                    builder.Append($" {nextWords[twoLastWords]}");
                }
                else if (nextWords.ContainsKey(lastWord)) {
                    builder.Append($" {nextWords[lastWord]}");
                }
            }
            else if (nextWords.ContainsKey(lastWord)) {
                builder.Append($" {nextWords[lastWord]}");
            }
        }

        return builder.ToString();
    }
}