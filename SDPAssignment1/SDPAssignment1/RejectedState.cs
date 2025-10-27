using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SDPAssignment1
{
    public class RejectedState : DocumentState
    {
        private Document document;

        public RejectedState(Document document) => this.document = document;

        public void AddCollaborator(User collaborator)
        {
            Console.WriteLine("Cannot add collaborators to a rejected document.");
        }

        public void SubmitForApproval()
        {
            Console.WriteLine("Document has already been rejected. Please revise and resubmit.");
        }

        public void SetApprover(User approver)
        {
            Console.WriteLine("Document has already been rejected and cannot be approved.");
        }

        public void DocumentApproved() => Console.WriteLine("Cannot approve a rejected document.");
        public void DocumentRejected(string reason) => Console.WriteLine("Document is already rejected.");
        public void DocumentPushBack(string comment) => Console.WriteLine("Cannot push back a rejected document.");

        public void DocumentRevised(string text, User editor)
        {
            document.EditContent(text, editor);
            document.SetState(document.Draft);
            Console.WriteLine($"Edited by {editor.Name}: {text}");
            Console.WriteLine("Document has been revised and is now in the Draft state.");

        }

        public void Create()
        {
            Console.WriteLine("Document has already been created!");
        }
    }
}


