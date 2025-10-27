using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPAssignment1
{
    public class GrantProposalFactory : DocumentFactory
    {
        protected override Document CreateDocument(string title, User owner)
        {
            Console.WriteLine("Creating a Grant Proposal...");
            return new GrantProposalDocument(title, owner);
        }
    }
}
