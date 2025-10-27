using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPAssignment1
{
    internal class UnderReview : DocumentState
    {
        private Document document;

        public UnderReview(Document document)
        {
            this.document = document;
        }

        public void Create()
        {
            Console.WriteLine("Document has already been created!");
        }

        public void DocumentRevised(string text, User editor)
        {
            Console.WriteLine("Document is currently under review and cannot be revised.");
        }

        public void SubmitForApproval()
        {
            Console.WriteLine("Document has already been submitted for approval!");
        }

        public void DocumentApproved()
        {
            document.SetState(document.Approved);
            Console.WriteLine("Document has been approved.");
        }

        public void DocumentRejected(string reason)
        {
            document.SetState(document.Rejected);
            Console.WriteLine("Document has been rejected.");
        }

        public void DocumentPushBack(string comment)
        {
            document.SetState(document.PushBack);
            Console.WriteLine("Document has been pushed back.");
        }
    }
}
