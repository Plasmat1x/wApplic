using wapi.Domain.Entities.Idenity;

namespace wapi.Domain.Entities {
    public class Article {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string AuthorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }

        //navigation
        public AppUser Author { get; set; }
        public IList<Image> Images { get; set; }
    }
}
