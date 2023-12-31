using wapi.Domain.Repositories.Abstract;

namespace wapi.Domain {
    public class DataManager {
        public IArticleRepository Articles { get; set; }
        public IImageRepository Images { get; set; }

        public DataManager(IArticleRepository articleRepository, IImageRepository imageRepository) {
            this.Articles = articleRepository;
            this.Images = imageRepository;
        }
    }

}
