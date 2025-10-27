namespace SDPAssignment1{

    public class CollaboratorFilter : IDocumentFilterStrategy
{
    private readonly User _collaborator;

    public CollaboratorFilter(User collaborator)
    {
        _collaborator = collaborator;
    }

    public List<Document> Filter(List<Document> documents)
    {
        return documents.Where(d => d.Collaborators.Contains(_collaborator)).ToList();
    }
}





}

