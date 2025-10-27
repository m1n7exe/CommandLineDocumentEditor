namespace SDPAssignment1{

        public class NameFilter : IDocumentFilterStrategy
    {
        private readonly string _name;

        public NameFilter(string name)
        {
            _name = name;
        }

        public List<Document> Filter(List<Document> documents)
        {
            return documents.Where(d => d.Name.Contains(_name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }





}
