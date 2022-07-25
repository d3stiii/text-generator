using NUnit.Framework;

namespace TextGenerator.Tests;

[TestFixture]
public class ParserTests {
    [Test]
    public void ParseEmptyText() {
        ParseText("", new List<List<string>>());
    }

    [Test]
    public void ParseTwoSentences() {
        ParseText(". lala; xd tests?", new List<List<string>> {
            new() { "lala" },
            new() { "xd", "tests" }
        });
    }

    private void ParseText(string text, List<List<string>> expected) {
        TextParser parser = new TextParser();
        var result = parser.ParseSentences(text);

        Assert.That(result.Count, Is.EqualTo(expected.Count));

        for (int i = 0; i < expected.Count; i++) {
            Assert.That(result[i].Count, Is.EqualTo(expected[i].Count));

            for (int j = 0; j < expected[i].Count; j++)
                Assert.That(result[i][j], Is.EqualTo(expected[i][j]));
        }
    }
}