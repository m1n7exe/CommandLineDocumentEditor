using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPAssignment1
{
    public interface Subject
    {
        void RegisterObserver(User observer);
        void RemoveObserver(User observer);
        void NotifyObserver(User observer, string message);
    }
}
