namespace SDPAssignment1{

    public class FileTypeFilter : IDocumentFilterStrategy
{
    private readonly string _extension;

    public FileTypeFilter(string extension)
    {
        _extension = extension;
    }

    public List<Document> Filter(List<Document> documents)
    {
        return documents.Where(d => d.Extension.Equals(_extension, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}



}
