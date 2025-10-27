using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SDPAssignment1
{
    public class EditCommand : ICommand
    {
        private Document _document;
        private string Text;
        private User Editor;
        private string PreviousContent;

        public EditCommand(Document document, string text, User editor)
        {
            _document = document;
            Text = text;
            this.Editor = editor;
            PreviousContent = document.Content; // Save the previous state for undo
        }

        public void Execute()
        {
            Console.WriteLine($"Executing EditCommand: Adding '{Text}' by {Editor.Name}");
            _document.GetState().DocumentRevised(Text, Editor);
        }

        public void Undo()
        {
            Console.WriteLine($"Undoing EditCommand: Reverting content to '{PreviousContent}'");
            _document.SetContent(PreviousContent); // Restore the previous content
        }
    }
}

