using System;
using System.Collections.Generic;
using System.Linq;

namespace SDPAssignment1
{
    public class Approver : User
    {
        public void Approve(Document document)
        {
            if (document.Approver == this)
            {
                document.DocumentApproved();
                Console.WriteLine($"{Name} approved the document.");
            }
            else
            {
                Console.WriteLine("You are not the approver of this document.");
            }
        }

        public void Reject(Document document, string reason)
        {
            if (document.Approver == this)
            {
                document.DocumentRejected(reason);
                Console.WriteLine($"{Name} rejected the document.");
            }
            else
            {
                Console.WriteLine("You are not the approver of this document.");
            }
        }

        public void PushBack(Document document, string comment)
        {
            if (document.Approver == this)
            {
                document.DocumentPushBack(comment);
                Console.WriteLine($"{Name} pushed back the document with comment: {comment}");
            }
            else
            {
                Console.WriteLine("You are not the approver of this document.");
            }
        }

        public void ViewDocumentsUnderReview()
        {
            Console.WriteLine($"{Name}'s documents under review:");
        }
    }
}