using System;

namespace SDPAssignment1
{
    public class ApprovedState : DocumentState
    {
        private Document document;

        public ApprovedState(Document document) => this.document = document;

        public void AddCollaborator(User collaborator) 
        {
            Console.WriteLine("Cannot add collaborators to an approved document.");
        }

        public void SubmitForApproval() 
        {
            Console.WriteLine("Document is already approved.");
        }

        public void SetApprover(User approver) 
        {
            Console.WriteLine("Approver is already set.");
        }

        public void DocumentApproved() 
        {
            Console.WriteLine("Document is already approved.");
        }

        public void DocumentRejected(string reason) 
        {
            Console.WriteLine("Cannot reject an approved document.");
        }

        public void DocumentPushBack(string comment) 
        {
            Console.WriteLine("Cannot push back an approved document.");
        }

        public void DocumentRevised(string text, User editor) 
        {
            Console.WriteLine("Cannot edit an approved document.");
        }

        // Add the missing Create() method from the DocumentState interface
        public void Create() 
        {
            Console.WriteLine("Document is already approved and cannot be created again.");
            // Adjust the behavior based on your requirements
        }
    }
}
