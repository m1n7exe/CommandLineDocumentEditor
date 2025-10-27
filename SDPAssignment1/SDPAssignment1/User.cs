using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPAssignment1
{
    public abstract class User
    {
        public string Name { get; set; }
        public string Role { get; set; }

        public List<Document> OwnedDocuments { get; private set; } = new List<Document>();

        public virtual void Notify(string message)
        {
            Console.WriteLine($"{Name} ({Role}) received notification: {message}");
        }

        public void ShareDocument(Document document, User collaborator)
        {
        if (OwnedDocuments.Contains(document))
        {
            document.AddCollaborator(collaborator);
            Console.WriteLine($"{collaborator.Name} can now access '{document.Name}'.");
        }
        else
        {
            Console.WriteLine("You do not own this document.");
        }
        }
    }
}

