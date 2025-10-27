using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPAssignment1
{
    public class TechnicalReportFactory : DocumentFactory
    {
        protected override Document CreateDocument(string title, User owner)
        {
            Console.WriteLine("Creating a Technical Report...");
            return new TechnicalReportDocument(title, owner);
        }
    }
}
