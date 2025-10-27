namespace SDPAssignment1{
    public class GrantProposalDocument : Document
    {
        public GrantProposalDocument(string title, User owner) 
            : base(title, "Grant Proposal Header", "Grant Proposal Footer", "This is the body of the grant proposal.", "docx", owner)
        {
            // Explicitly call InitializeDocument after the base class constructor
            InitializeDocument();
        }

        // Explicitly override InitializeDocument() to provide custom behavior
        public override void InitializeDocument()
        {
            SetHeader("Research Paper Header");
            SetContent("This is the body of the research paper.");
            SetFooter("Research Paper Footer");
            Console.WriteLine("Grant Paper initialized...");
        }
        
    }

}