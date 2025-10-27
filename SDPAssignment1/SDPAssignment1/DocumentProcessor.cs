public class DocumentProcessor
{
    private IDocumentConverter? _converter;

    // Set the converter strategy
    public void SetConverter(IDocumentConverter converter)
    {
        _converter = converter;
    }

    // Convert a document using the selected strategy
    public void ConvertDocument(Document document)
{
    if (_converter == null)
    {
        Console.WriteLine("No conversion strategy set.");
        return;
    }

    // Check if document is already converted
    if (document.Extension != ".docx")
    {
        _converter.Convert(document);
    }
    else
    {
        Console.WriteLine("Document is already in the target format.");
    }
}

    public void DisplayDocuments()
{
    if (Document.Documents.Count == 0)
    {
        Console.WriteLine("No documents available.");
        return;
    }

    Console.Clear();
    Console.WriteLine("Documents:\n");

    // Only display documents with their extensions
    foreach (var doc in Document.Documents)
    {
        Console.WriteLine($"{doc.Name} ({doc.Extension})");
    }

    Console.WriteLine("\nPress any key to return.");
    Console.ReadKey();
}

}

