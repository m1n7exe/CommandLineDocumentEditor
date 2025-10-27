using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPAssignment1
{
    public class OwnerFactory : UserFactory
    {
        protected override User CreateUser(string name)
        {
            return new Owner { Name = name, Role = "Owner" };
        }
    }
}
