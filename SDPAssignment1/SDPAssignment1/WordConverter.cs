public class WordConverter : IDocumentConverter
{
    public void Convert(Document document)
    {
        Console.WriteLine($"\nConverting {document.Name} to Word...");
        
        // Only change the extension to .docx if it isn't already .docx
        if (document.Extension != ".docx")
        {
            document.Extension = ".docx";
            // Add your conversion logic here (e.g., using a library like iTextSharp)
            Console.WriteLine($"{document.Name} converted to Word successfully.");
        }
        else
        {
            Console.WriteLine($"{document.Name} is already in Word format.");
        }
    }
}
