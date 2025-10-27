using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPAssignment1
{
    public class ApproveCommand : ICommand
    {
        private Document _document;
        private DocumentState PreviousState;

        public ApproveCommand(Document document)
        {
            _document = document;
            PreviousState = document.GetState(); // Save the previous state for undo
        }

        public void Execute()
        {
            Console.WriteLine("Executing ApproveCommand: Approving document.");
            _document.DocumentApproved();
        }

        public void Undo()
        {
            Console.WriteLine("Undoing ApproveCommand: Reverting to previous state.");
            _document.SetState(PreviousState); // Restore the previous state
        }


    }
}
