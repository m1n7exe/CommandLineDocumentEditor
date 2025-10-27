//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SDPAssignment1
//{
//    public class UserManager
//    {
//        private List<User> users = new List<User>();
//        private User currentUser;

//        public void CreateUser(string name)
//        {
//            // Default to creating a generic User
//            User user = new User(name);
//            users.Add(user);
//            Console.WriteLine($"{name} has been created.");
//        }

//        public void LoginUser(string name)
//        {
//            User user = users.Find(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
//            if (user != null)
//            {
//                currentUser = user;
//                Console.WriteLine($"Logged in as {user.Name}.");
//            }
//            else
//            {
//                Console.WriteLine("User not found.");
//            }
//        }

//        public void ListUsers()
//        {
//            Console.WriteLine("List of users:");
//            foreach (var user in users)
//            {
//                Console.WriteLine($"- {user.Name}");
//            }
//        }

//        public User FindUserByName(string name)
//        {
//            return users.Find(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
//        }

//        public User CurrentUser => currentUser;
//        public List<User> Users => users;
//    }
//}
