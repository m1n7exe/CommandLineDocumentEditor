using SDPAssignment1;


public class Document
{
    public string Name { get; set; }
    public string Header { get; set; }
    public string Footer { get; set; }
    public string Content { get; set; }
    public User Owner { get; set; }
    public List<User> Collaborators { get; set; } = new List<User>();
    public User? Approver { get; set; }
    public static List<Document> Documents { get; set; } = new List<Document>();

    public string Extension { get; set; }  // Stores "docx" or "pdf"

    public int EditCount {get; private set;} = 0;

    // State objects
    private DocumentState draft;
    private DocumentState underReview;
    private DocumentState approved;
    private DocumentState rejected;
    private DocumentState pushBack;

    // Setting Header, Footer and Content

    public void SetHeader(string header){
        Header = header;
    }

    public void SetFooter(string footer){
        Footer = footer;
    }

    public void SetContent(string content){
        Content = content;
    }
    // Public properties to expose states
    public DocumentState Draft
    {
        get { return draft; }
    }

    public DocumentState UnderReview
    {
        get { return underReview; }
    }

    public DocumentState Approved
    {
        get { return approved; }
    }

    public DocumentState Rejected
    {
        get { return rejected; }
    }

    public DocumentState PushBack
    {
        get { return pushBack; }
    }

    public DocumentState State { get; private set; }

    public Document(string name, string header, string footer, string content, string extension, User owner)
    {
        Name = name;
        Header = header;
        Footer = footer;
        Content = content;
        Owner = owner;
        Extension = extension;

        // Initialize the edit count
        EditCount = 0;

        // Initialize states
        draft = new Draft(this);
        underReview = new UnderReview(this);
        approved = new Approved(this);
        rejected = new Rejected(this);
        pushBack = new PushBack(this);

        // Set initial state
        State = draft;

        // Add document to static list
        Documents.Add(this);

        // Call InitializeDocument after constructor setup
        InitializeDocument();
    }
    public void ResetEditCount()
    {
        EditCount = 0;
        Console.WriteLine("Edit count has been reset.");
    }
    // Virtual method to be overridden in derived classes like GrantProposalDocument
    public virtual void InitializeDocument()
    {
        // Provide default behavior or leave it empty if needed
        Console.WriteLine("Document initialized...");
    }

    public void SetState(DocumentState newState)
    {
        State = newState;
    }

    public void Create()
    {
        State.Create();
    }

    public void DocumentRevised(string text, User editor)
    {
        State.DocumentRevised(text, editor);
    }

    public void SubmitForApproval()
    {
        State.SubmitForApproval();
    }

    public void DocumentApproved()
    {
        State.DocumentApproved();
    }

    public void DocumentRejected(string reason)
    {
        State.DocumentRejected(reason);
    }

    public void DocumentPushBack(string comment)
    {
        State.DocumentPushBack(comment);
    }

     public void EditContent(string text, User editor)
    {
        EditCount++;
        Console.WriteLine("Document content has been updated.");
    }

    public void AddCollaborator(User collaborator)
    {
        if (collaborator == null)
        {
            Console.WriteLine("Invalid collaborator.");
            return;
        }
        
        Collaborators.Add(collaborator);
        Console.WriteLine($"{collaborator.Name} has been added as a collaborator.");
    }

    public DocumentState GetState()
    {
        return State;
    }

    public void Submit()
    {
        Console.WriteLine("Document is being submitted...");
        // Transition the document to the "Under Review" state
        SetState(underReview);
    }

}
