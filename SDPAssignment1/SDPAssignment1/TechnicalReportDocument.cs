using SDPAssignment1;

public class TechnicalReportDocument : Document
{
    public TechnicalReportDocument(string title, User owner) 
        : base(title, "Technical Report Proposal Header", "Technical Report Proposal Footer", "This is the body of the Technical Report proposal.", "docx", owner)
    {
        // The constructor calls InitializeDocument() from the base class
        InitializeDocument();
    }

    // Explicitly override InitializeDocument()
    public override void InitializeDocument()
    {
        // Use the setter methods to set header, content, and footer
        SetHeader("Technical Report Header");
        SetContent("This is the body of the technical report.");
        SetFooter("Technical Report Footer");
        Console.WriteLine("Technical Report initialized...");
    }
}
