namespace App;

public class FileDataHandler
{
    private static readonly string FolderPath = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.Parent!.FullName;
    private static readonly string InputFilePath = Path.Combine(FolderPath, InputFileName);
    private static readonly string OutputFilePath = Path.Combine(FolderPath, OutputFileName);
    private const string OutputFileName = "OUTPUT.TXT";
    private const string InputFileName = "INPUT.TXT";

    public static int ReadNumberFromFile()
    {
        if (!File.Exists(InputFilePath))
        {
            throw new FileNotFoundException($"The file {InputFileName} was not found.");
        }

        var lines = File.ReadAllLines(InputFilePath)
            .Select(static line => line.Trim())
            .Where(static line => !string.IsNullOrWhiteSpace(line))
            .ToArray();
        if (lines.Length == 0)
        {
            throw new InvalidDataException("The file does not contain any text");
        }

        if (lines.Length != 1)
        {
            throw new InvalidDataException("The file must contain only one number");
        }

        if (!int.TryParse(lines[0], out var n))
        {
            throw new InvalidDataException("The file must contain an integer");
        }

        return n;
    }

    public static void WriteResultToFile(int result)
    {
        File.WriteAllText(OutputFilePath, result.ToString());
    }
}
