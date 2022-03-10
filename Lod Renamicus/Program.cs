
using System.Text.RegularExpressions;

static class Program
{
    static void Main(string[] args)
    {
        // Assume folder will be argument given
        string SubFolderToCheck = args[0];
        var FileList = new List<FileEntry>();
        var FileNameMatcher = new Regex(@"(\d+)_-_(.+)_LOD(\d+)\.Mesh");
        foreach (string File in Directory.EnumerateFiles(SubFolderToCheck, "*.Mesh"))
        {
            Console.WriteLine(File);
            var BaseFileName = Path.GetFileName(File);
            Match TheMatchItself = FileNameMatcher.Match(BaseFileName);
            if (TheMatchItself.Success)
            {
                var Entry = new FileEntry();
                Entry.FileIndex = int.Parse(TheMatchItself.Groups[1].Value);
                Entry.BaseFileName = TheMatchItself.Groups[2].Value;
                Entry.LODIndex = int.Parse(TheMatchItself.Groups[3].Value);
                FileList.Add(Entry);

            }
        }
    }
}



class FileEntry
{
    public int FileIndex;
    public string BaseFileName;
    public int LODIndex;

}