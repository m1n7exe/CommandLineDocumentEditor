
namespace SDPAssignment1{

        public interface DocumentState
    {
        void Create();
        void DocumentRevised(string text, User editor);  
        void SubmitForApproval();
        void DocumentApproved();
        void DocumentRejected(string reason);  
        void DocumentPushBack(string comment);  
    }



}

