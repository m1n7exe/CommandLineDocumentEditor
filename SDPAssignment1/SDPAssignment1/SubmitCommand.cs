using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPAssignment1
{
    public class SubmitCommand : ICommand
    {
        private Document _document;
        private DocumentState PreviousState;

        public SubmitCommand(Document document)
        {
            _document = document;
            PreviousState = _document.GetState(); // Save the previous state for undo
        }

        public void Execute()
        {
            Console.WriteLine("Executing SubmitCommand: Submitting document for review.");
            _document.Submit();
        }

        public void Undo()
        {
            Console.WriteLine("Undoing SubmitCommand: Reverting to previous state.");
            _document.SetState(PreviousState); // Restore the previous state
        }
    }
}
