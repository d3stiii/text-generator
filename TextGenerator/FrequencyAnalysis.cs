namespace TextGenerator;

public class FrequencyAnalysis {
    public Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text) {
        var couple = new Dictionary<string, Dictionary<string, int>>();
        foreach (var sentence in text) {
            for (int i = 0; i < sentence.Count; i++) {
                if (sentence.Count > i + 1)
                    MakeNGram(couple, sentence[i], sentence[i + 1]);
                if (sentence.Count > i + 2)
                    MakeNGram(couple, $"{sentence[i]} {sentence[i + 1]}", sentence[i + 2]);
            }
        }

        return SortOrder(couple);
    }

    private void MakeNGram(Dictionary<string, Dictionary<string, int>> couple,
        string startWord, string nextWord) {
        if (!couple.ContainsKey(startWord))
            couple.Add(startWord, new Dictionary<string, int>());

        if (couple[startWord].ContainsKey(nextWord))
            couple[startWord][nextWord]++;
        else
            couple[startWord].Add(nextWord, 1);
    }

    private Dictionary<string, string> SortOrder(Dictionary<string, Dictionary<string, int>> couple) {
        var result = new Dictionary<string, string>(couple.Count);

        foreach (var item in couple) {
            result.Add(item.Key,
                item.Value.OrderByDescending(x => x.Value).ThenBy(s => s.Key, StringComparer.Ordinal).First().Key);
        }

        return result;
    }
}