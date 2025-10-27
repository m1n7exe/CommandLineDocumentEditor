using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPAssignment1
{
    public class DraftState : DocumentState
    {
    private Document document;

    public DraftState(Document document) => this.document = document;

    public void AddCollaborator(User collaborator)
    {
        Console.WriteLine($"{collaborator.Name} added as a collaborator.");
    }

    public void SubmitForApproval()
    {
        if (document.Approver == null)
        {
            Console.WriteLine("Please set an approver first!");
            return;
        }
        Console.WriteLine("Document submitted for review.");
        document.SetState(document.UnderReview);

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

    // Implement Create method
    public void Create()
    {
        Console.WriteLine("Document created in Draft state.");
    }

    public void DocumentApproved() => Console.WriteLine("Cannot approve a draft document.");
    public void DocumentRejected(string reason) => Console.WriteLine("Cannot reject a draft document.");
    public void DocumentPushBack(string comment) => Console.WriteLine("Cannot push back a draft document.");

    // Implement DocumentRevised method with the correct signature
    public void DocumentRevised(string text, User editor)
    {
        document.EditContent(text, editor);
        Console.WriteLine($"Edited by {editor.Name}: {text}");
    }
    }
}