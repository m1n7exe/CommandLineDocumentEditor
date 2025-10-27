using System;
using System.Collections.Generic;
using System.Linq;

namespace SDPAssignment1
{
    public class Collaborator : User
    {
        public void EditDocument(Document document, string content)
        {
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

        public void SubmitForApproval(Document document, User approver)
        {
            if (!document.Collaborators.Contains(approver) && document.Owner != approver)
            {
                document.Approver = approver;
                document.SubmitForApproval();
                Console.WriteLine($"{Name} submitted the document for approval.");
            }
            else
            {
                Console.WriteLine("The approver cannot be a collaborator or the owner.");
            }
        }

        // Method to view all documents the collaborator is associated with
        public void ViewAssociatedDocuments()
        {
            Console.WriteLine($"{Name}'s associated documents:");
            var associatedDocuments = Document.Documents.Where(doc =>
                doc.Collaborators.Contains(this) || doc.Owner == this);

            if (!associatedDocuments.Any())
            {
                Console.WriteLine("You are not associated with any documents.");
                return;
            }

            foreach (var doc in associatedDocuments)
            {
                Console.WriteLine($"- {doc.Name} (State: {doc.State.GetType().Name})");
            }
        }
    }
}