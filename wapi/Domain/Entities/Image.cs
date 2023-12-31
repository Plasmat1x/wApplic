namespace wapi.Domain.Entities {
    public class Image {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Uploaded { get; set; }
        public string Path { get; set; }
        public string ArticleId { get; set; }

        //navigation
        public Article Article { get; set; }

    }
}
