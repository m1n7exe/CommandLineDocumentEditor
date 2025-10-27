using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPAssignment1
{
    public class Draft : DocumentState
    {
        private Document document;

        public Draft(Document document)
        {
            this.document = document;
        }

        public void Create()
        {
            Console.WriteLine("Document has already been created!");
        }

        public void DocumentRevised(string text, User editor)
        {
            Console.WriteLine("Document is being revised...");
        }

        public void SubmitForApproval()
        {
            document.SetState(document.UnderReview);
            Console.WriteLine("Document has been submitted for approval.");
        }

        public void DocumentApproved()
        {
            Console.WriteLine("You are not the approver of this document.");
        }

        public void DocumentRejected(string reason)
        {
            Console.WriteLine("You are not the approver of this document.");
        }

        public void DocumentPushBack(string comment)
        {
            Console.WriteLine("You are not the approver of this document.");
        }
    }
}
