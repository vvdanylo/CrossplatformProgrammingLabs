namespace App;

public static class FileDataHandler
{
    private static readonly string FolderPath = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.Parent!.FullName;
    private static readonly string InputFilePath = Path.Combine(FolderPath, InputFileName);
    private static readonly string OutputFilePath = Path.Combine(FolderPath, OutputFileName);
    private const string OutputFileName = "OUTPUT.TXT";
    private const string InputFileName = "INPUT.TXT";

    public static (string s, string t) ReadDnaSequencesFromFile()
    {
        if (!File.Exists(InputFilePath))
        {
            throw new FileNotFoundException($"File was not found");
        }

        var lines = File.ReadAllLines(InputFilePath)
            .Select(line => line.Trim())
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .ToArray();

        if (lines.Length == 0)
        {
            throw new Exception("No sequence in the provided file");
        }

        if (lines.Length != 2)
        {
            throw new Exception("File must contain only two rows");
        }

        var subsequence = lines[0];
        var sequence = lines[1];

        return (subsequence, sequence);
    }

    public static void WriteResultToFile(string result)
    {
        File.WriteAllText(OutputFilePath, result);
    }

    private static bool IsGeneticSequence(string sequence)
    {
        return sequence.All(c => c == 'A' || c == 'C' || c == 'G' || c == 'T');
    }
}
