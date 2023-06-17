namespace Utilities;

public class StringUtilities
{
public static int ToWords(string input)
    {
        string[] words = input.Split(' ');
        HashSet<string> uniqueWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (string word in words)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {
                uniqueWords.Add(word);
            }
        }

        return uniqueWords.Count;
    }
}
