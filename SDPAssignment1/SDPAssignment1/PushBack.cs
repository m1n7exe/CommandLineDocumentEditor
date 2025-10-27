using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPAssignment1
{
    internal class PushBack : DocumentState
    {
        private Document document;

        public PushBack(Document document)
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
            Console.WriteLine("Document has already been pushed back, you can revise your document and submit for approval again.");
        }

        public void DocumentApproved()
        {
            Console.WriteLine("Document has already been pushed back, Document can't be Approved");
        }

        public void DocumentRejected(string reason)
        {
            Console.WriteLine("Document has already been pushed back, Document can't be rejected");
        }

        public void DocumentPushBack(string comment)
        {
            Console.WriteLine("Document has already been pushed back, Document can't be pushed back");
        }
    }
}
