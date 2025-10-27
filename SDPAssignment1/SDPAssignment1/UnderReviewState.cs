using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPAssignment1
{
    public class UnderReviewState : DocumentState
    {
        private Document document;

        public UnderReviewState(Document document) => this.document = document;

        public void AddCollaborator(User collaborator)
        {
            document.AddCollaborator(collaborator);
            Console.WriteLine($"{collaborator.Name} added as a collaborator.");
        }

        public void SubmitForApproval() => Console.WriteLine("Document is already under review.");

        public void SetApprover(User approver) => Console.WriteLine("Approver is already set.");

        public void DocumentApproved()
        {
            Console.WriteLine("Document approved.");
            document.SetState(document.Approved);
        }

        public void DocumentRejected(string reason)
        {
            document.ResetEditCount(); // Reset EditCount using the public method
            Console.WriteLine($"Document rejected: {reason}");
            document.SetState(document.Rejected);
        }

        public void DocumentPushBack(string comment)
        {
            document.ResetEditCount(); // Reset EditCount using the public method
            Console.WriteLine($"Document pushed back: {comment}");
            document.SetState(document.PushBack); // Transition to PushBackState

        }
        public void Create(){
            Console.WriteLine("");
        }
        public void DocumentRevised(string text, User editor) => Console.WriteLine("Cannot edit document under review.");
    }
}
