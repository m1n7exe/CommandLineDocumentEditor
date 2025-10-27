using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SDPAssignment1
{
    public abstract class AbstractDocument
    {
        public string Title { get; protected set; }
        public string Header { get; protected set; }

        public string Content { get; protected set; }
        public string Footer { get; protected set; }

        // Abstract methods for document-specific initialization
        public abstract void InitializeDocument();

        // Common methods that can be shared across all documents
        public virtual void SetHeader(string header)
        {
            Header = header;
            Console.WriteLine($"Header set to: {header}");
        }

        public virtual void SetContent(string content)
        {
            Content = content;
            Console.WriteLine($"Content set to: {content}");
        }

        public virtual void SetFooter(string footer)
        {
            Footer = footer;
            Console.WriteLine($"Footer set to: {footer}");
        }
    }
}
