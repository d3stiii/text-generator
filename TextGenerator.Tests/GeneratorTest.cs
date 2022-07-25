using NUnit.Framework;

namespace TextGenerator.Tests;

[TestFixture]
public class GeneratorTest {
    [Test]
    public void TestGeneration() {
        GenerateText(new Dictionary<string, string> {
            { "lalalala", "unit" },
            { "unit", "tests" },
            { "tests", "are" },
            { "tests are", "good" }
        }, "lalalala", "lalalala unit tests are good");
    }

    private void GenerateText(Dictionary<string, string> nextWords, string phraseBeginning, string expected) {
        var generator = new TextGenerator();
        string result = generator.ContinuePhrase(nextWords, phraseBeginning, 5);

        Assert.That(result, Is.EqualTo(expected));
    }
}