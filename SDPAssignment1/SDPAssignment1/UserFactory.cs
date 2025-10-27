using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDPAssignment1
{
    public abstract class UserFactory
    {
        // Public method to launch a user creation process
        public User LaunchUser(string name)
        {
            User user = CreateUser(name);
            Console.WriteLine($"{user.Name} has been created.");
            return user;
        }

        // Abstract method to be implemented by concrete factories
        protected abstract User CreateUser(string name);
    }
}
