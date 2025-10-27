using System;

namespace SDPAssignment1
{
    public class PushBackState : DocumentState
    {
        private Document document;

        public PushBackState(Document document) => this.document = document;

        public void AddCollaborator(User collaborator)
        {
            Console.WriteLine($"{collaborator.Name} added as a collaborator.");
        }

        public void SubmitForApproval()
        {
            if (document.EditCount > 0)
            {
                Console.WriteLine("Document resubmitted for review.");
                document.SetState(document.UnderReview);
            }
            else
            {
                Console.WriteLine("Document must be edited before resubmission.");
            }
        }

        public void SetApprover(User approver)
        {
            if (document.Collaborators.Contains(approver) || document.Owner == approver)
            {
                Console.WriteLine("Approver cannot be a collaborator or the owner!");
                return;
            }
            document.Approver = approver;
            Console.WriteLine($"{approver.Name} set as approver.");
        }

        public void DocumentApproved() => Console.WriteLine("Cannot approve a pushed-back document.");

        public void DocumentRejected(string reason) => Console.WriteLine("Cannot reject a pushed-back document.");

        public void DocumentPushBack(string comment) => Console.WriteLine("Document is already pushed back.");

        public void DocumentRevised(string text, User editor)
        {
            document.EditContent(text, editor);
            Console.WriteLine($"Edited by {editor.Name}: {text}");
        }

        // Add the missing Create() method from the DocumentState interface
        public void Create()
        {
            Console.WriteLine("Document is in PushBack state and cannot be created.");
            // You can handle it accordingly based on your application logic
        }
    }
}
