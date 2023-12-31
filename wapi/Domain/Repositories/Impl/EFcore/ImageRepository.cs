using wapi.Domain.Entities;
using wapi.Domain.Repositories.Abstract;

namespace wapi.Domain.Repositories.Impl.EFcore {
    public class ImageRepository: IImageRepository {
        private readonly AppDbContext context;

        public ImageRepository(AppDbContext context) {
            this.context = context;
        }

        public Task CreateImage(Image image, CancellationToken ct) {
            throw new NotImplementedException();
        }

        public Task DeletImage(string id, CancellationToken ct) {
            throw new NotImplementedException();
        }

        public Task<Image> GetImage(string id, CancellationToken ct) {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Image>> GetImages(string articleId, CancellationToken ct) {
            throw new NotImplementedException();
        }

        public Task UpadteImage(Image image, CancellationToken ct) {
            throw new NotImplementedException();
        }
    }
}
