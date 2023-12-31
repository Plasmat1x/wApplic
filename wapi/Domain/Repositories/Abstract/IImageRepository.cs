using wapi.Domain.Entities;

namespace wapi.Domain.Repositories.Abstract {
    public interface IImageRepository {
        Task<IQueryable<Image>> GetImages(string articleId, CancellationToken ct = default);
        Task<Image> GetImage(string id, CancellationToken ct = default);
        Task DeletImage(string id, CancellationToken ct = default);
        Task CreateImage(Image image, CancellationToken ct = default);
        Task UpadteImage(Image image, CancellationToken ct = default);
    }
}
