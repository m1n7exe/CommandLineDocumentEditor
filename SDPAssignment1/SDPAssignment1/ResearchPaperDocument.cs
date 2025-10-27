using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPAssignment1
{
    public class ResearchPaperDocument : Document
    {
        public ResearchPaperDocument(string title, User owner) 
            : base(title, "Grant Proposal Header", "Grant Proposal Footer", "This is the body of the grant proposal.", "docx", owner)
        {
            // The constructor calls InitializeDocument() from the base class
        }

        // Explicitly override InitializeDocument()
        public override void InitializeDocument()
        {
            // Use the abstract methods to set header, content, and footer
            SetHeader("Research Paper Header");
            SetContent("This is the body of the research paper.");
            SetFooter("Research Paper Footer");
            Console.WriteLine("Research Paper initialized...");
        }
    }
}
