using NUnit.Framework;

namespace TextGenerator.Tests;

[TestFixture]
public class FrequencyAnaliseTests {
    [Test]
    public void FrequencyWithBiagram() {
        AnaliseFrequency(new List<List<string>> {
            new() { "some" },
            new() { "unit", "tests" }
        }, new Dictionary<string, string> {
            { "unit", "tests" },
        });
    }

    private void AnaliseFrequency(List<List<string>> sentences, Dictionary<string, string> expected) {
        var frequencyAnalysis = new FrequencyAnalysis();
        var result = frequencyAnalysis.GetMostFrequentNextWords(sentences);

        Assert.Multiple(() => {
            Assert.That(result.Count, Is.EqualTo(expected.Count));
            Assert.That(ConvertDictionaryToString(result), Is.EqualTo(ConvertDictionaryToString(expected)));
        });
    }

    private static string ConvertDictionaryToString(Dictionary<string, string> dictionary) {
        var pairStrings = dictionary
            .OrderBy(p => p.Key)
            .Select(p => p.Key + ": " + string.Join(", ", p.Value));
        return string.Join("; ", pairStrings);
    }
}