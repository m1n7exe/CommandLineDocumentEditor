public class PDFConverter : IDocumentConverter
{
    public void Convert(Document document)
    {
        Console.WriteLine($"\nConverting {document.Name} to PDF...");
        
        // Only change the extension to .pdf if it isn't already .pdf
        if (document.Extension != ".pdf")
        {
            document.Extension = ".pdf";
            
            Console.WriteLine($"{document.Name} converted to PDF successfully.");
        }
        else
        {
            Console.WriteLine($"{document.Name} is already in PDF format.");
        } 
    }
}
