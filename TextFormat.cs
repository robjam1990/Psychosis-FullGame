using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Project
{
    public class TextFormatter
    {
        private bool inWord = false;
        private StringBuilder word = new StringBuilder();
        private StringBuilder currentLine = new StringBuilder();
        private int WindowWidth;
        private int WordSize;
        private char C;
        private string[]? words;

        public TextFormatter(int windowSize, int wordSize, char c)
        {
            WindowWidth = windowSize;
            WordSize = wordSize;
            C = c;
        }

        public async Task<Tuple<string, string>> FormatTextAsync(string input, string targetLanguage)
        {
            var lines = input.Split(new[] { "\n", "\r\n" }, StringSplitOptions.None);
            var allFormattedLines = new StringBuilder();

            foreach (string line in lines)
            {
                var words = SplitExcludingAlphabet(line);

                var formattedWords = words
                    .Select((word, index) => FormatWord(word, index))
                    .ToList();

                var formattedLine = string.Join(", ", formattedWords);
                formattedLine = currentLine + formattedLine;

                if (formattedLine.Length > 80)
                {
                    WriteLine(currentLine.ToString());
                    currentLine.Clear();
                }

                currentLine.Append(formattedLine);

                if (currentLine.Length >= WindowWidth)
                {
                    allFormattedLines.AppendLine(currentLine.ToString());
                    currentLine.Clear();
                }
            }

            if (currentLine.Length > 0)
            {
                allFormattedLines.AppendLine(currentLine.ToString());
            }

            string runningAverage = $"Running Average: {CalculateRunningAverage(lines.Length)}";
            string windowAverage = $"Window Average: {CalculateWindowAverage(lines.Length)}";

            WriteLine(runningAverage);
            WriteLine(windowAverage);

            string translatedText = await TranslateTextAsync(allFormattedLines.ToString(), targetLanguage);

            return new Tuple<string, string>(allFormattedLines.ToString(), translatedText);
        }

        private IEnumerable<string> SplitExcludingAlphabet(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                yield break;
            }

            word.Clear();

            foreach (var c in input)
            {
                if (char.IsLetter(c))
                {
                    if (!inWord)
                    {
                        inWord = true;
                        word.Clear();
                    }
                    word.Append(c);
                }
                else
                {
                    if (inWord)
                    {
                        yield return word.ToString();
                        inWord = false;
                    }
                }
            }

            if (inWord)
            {
                yield return word.ToString();
            }
        }

        private string FormatWord(string word, int index)
        {
            return index switch
            {
                -8 => $"/ {word}",
                -7 => $"/ {word}",
                -6 => $"<{word}>",
                -5 => $"{{{word}}}",
                -4 => $"[{word}]",
                -3 => $"'{word}'",
                -2 => $"({word})",
                -1 => $"\"{word}\"",
                _ => word,
            };
        }

        private float CalculateRunningAverage(int length)
        {
            // Implement the logic to calculate the running average.
            return 0;
        }

        private float CalculateWindowAverage(int length)
        {
            // Implement the logic to calculate the window average.
            return 0;
        }

        private async Task<string> TranslateTextAsync(string text, string targetLanguage)
        {
            // Replace this with an actual language translation API call
            return await Task.Run(() =>
            {
                return $"Translated text in {targetLanguage}: {text}";
            });
        }

        private void WriteLine(string line)
        {
            // Implement your logging or output logic here
            System.Console.WriteLine(line);
        }
    }
}
