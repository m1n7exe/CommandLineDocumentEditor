using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SDPAssignment1
{
    internal class Rejected : DocumentState
    {
        private Document document;

        public Rejected(Document document)
        {
            this.document = document;
        }

        public void Create()
        {
            Console.WriteLine("Document has already been created!");
        }

        public void DocumentRevised(string text, User editor)
        {
            document.SetState(document.Draft);
            Console.WriteLine("Document has been revised and is now in the Draft state.");
        }

        public void SubmitForApproval()
        {
            Console.WriteLine("Document has already been rejected. Please revise and resubmit.");
        }

        public void DocumentApproved()
        {
            Console.WriteLine("Document has already been rejected and cannot be approved.");
        }

        public void DocumentRejected(string reason)
        {
            Console.WriteLine("Document has already been rejected.");
        }

        public void DocumentPushBack(string comment)
        {
            Console.WriteLine("Document has already been rejected.");
        }
    }
}


