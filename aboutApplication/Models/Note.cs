namespace aboutApplication.Models;

internal class Note
{
    public string FilePath { get; }
    public string Text { get; set; }

    public Note()
    {
        FilePath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "notes.txt"
        );
    }
}