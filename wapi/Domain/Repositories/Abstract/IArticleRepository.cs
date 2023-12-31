using wapi.Domain.Entities;

namespace wapi.Domain.Repositories.Abstract {
    public interface IArticleRepository {
        Task<IQueryable<Article>> GetArticles(CancellationToken ct = default);
        Task<Article> GetArticle(string id, CancellationToken ct = default);
        Task DeleteArticle(string id, CancellationToken ct = default);
        Task CreateArticle(Article article, CancellationToken ct = default);
        Task UpdateArticle(Article article, CancellationToken ct = default);
    }
}
