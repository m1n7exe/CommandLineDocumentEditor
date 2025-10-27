using System;
namespace SDPAssignment1
{
    public class CollaboratorFactory : UserFactory
    {
        protected override User CreateUser(string name)
        {
            return new Collaborator { Name = name, Role = "Collaborator" };
        }
    }
}