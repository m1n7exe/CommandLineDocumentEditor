using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPAssignment1
{
    public abstract class DocumentFactory
    {
        public Document LaunchDocument(string title, User owner)
        {
            // Delegate the creation of the document to the abstract method
            Document document = CreateDocument(title, owner);

            // Optionally, perform additional setup or logging here
            Console.WriteLine($"Launching document: {document.Name}");
            return document;
        }

        // Abstract method for creating specific types of documents
        protected abstract Document CreateDocument(string title, User owner);
    }
}

