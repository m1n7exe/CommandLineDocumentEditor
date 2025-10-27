using System;

namespace SDPAssignment1
{
    internal class Approved : DocumentState
    {
        private Document document;

        public Approved(Document document)
        {
            this.document = document;
        }

        public void Create()
        {
            Console.WriteLine("Document has already been created!");
        }

        public void DocumentRevised(string text, User editor)
        {
            Console.WriteLine("Document is already approved and cannot be revised.");
        }

        public void SubmitForApproval()
        {
            Console.WriteLine("Document has already been approved.");
        }

        public void DocumentApproved()
        {
            Console.WriteLine("Document has already been approved.");
        }

        // If your interface has the method, ensure you implement it here
        public void DocumentRejected(string reason)
        {
            Console.WriteLine("Document has already been approved and cannot be rejected.");
        }

        public void DocumentPushBack(string comment)
        {
            Console.WriteLine("Document has already been approved and cannot be pushed back.");
        }
    }
}
