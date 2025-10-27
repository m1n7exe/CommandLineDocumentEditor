using System;


namespace SDPAssignment1
{
    public class ApproverFactory : UserFactory
    {
        protected override User CreateUser(string name)
        {
            return new Approver { Name = name, Role = "Approver" };
        }
    }
}
