using System;
using System.Collections.Generic;
namespace SDPAssignment1
{
    public class Owner : User
    {
        public List<Document> OwnedDocuments { get; set; } = new List<Document>();

        // Method to add a collaborator to a document
        public void AddCollaborator(Document document, User collaborator)
        {
            if (document.Owner == this)
            {
                document.Collaborators.Add(collaborator);
                Console.WriteLine($"{collaborator.Name} has been added as a collaborator.");
            }
            else
            {
                Console.WriteLine("Only the owner can add collaborators.");
            }
        }

        // Method to view all owned documents
        public void ViewOwnedDocuments()
        {
            Console.WriteLine($"{Name}'s owned documents:");
            foreach (var doc in OwnedDocuments)
            {
                Console.WriteLine($"- {doc.Name}");
            }
        }

        // Method to add a document to the owner's list of owned documents
        public void AddOwnedDocument(Document document)
        {
            OwnedDocuments.Add(document);
            Console.WriteLine($"{document.Name} has been added to your owned documents.");
        }

        // Method to edit a document
        public void EditDocument(Document document, string content)
        {
            if (document.Owner != this)
            {
                Console.WriteLine("You do not own this document and cannot edit it.");
                return;
            }

            // Check if the document is in a state that allows editing
            if (document.State is Draft || document.State is PushBack)
            {
                document.Content = content;
                Console.WriteLine($"{Name} updated the document content.");
            }
            else
            {
                Console.WriteLine("Cannot edit document while it is under review.");
            }
        }

        // Method to submit a document for approval
        public void SubmitForApproval(Document document, User approver)
        {
            if (document.Owner != this)
            {
                Console.WriteLine("You do not own this document and cannot submit it for approval.");
                return;
            }

            // Ensure the approver is not a collaborator or the owner
            if (document.Collaborators.Contains(approver) || document.Owner == approver)
            {
                Console.WriteLine("The approver cannot be a collaborator or the owner.");
                return;
            }

            // Set the approver and submit the document for approval
            document.Approver = approver;
            document.SubmitForApproval();
            Console.WriteLine($"{Name} submitted the document for approval.");
        }
    }
}