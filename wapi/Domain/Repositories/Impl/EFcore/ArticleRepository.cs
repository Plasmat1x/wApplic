using Microsoft.EntityFrameworkCore;

using wapi.Domain.Entities;
using wapi.Domain.Repositories.Abstract;

namespace wapi.Domain.Repositories.Impl.EFcore {
    public class ArticleRepository: IArticleRepository {
        private readonly AppDbContext context;

        public ArticleRepository(AppDbContext context) {
            this.context = context;
        }

        public async Task CreateArticle(Article article, CancellationToken ct) {
            context.Articles.Add(article);
            await context.SaveChangesAsync(ct);
        }

        public async Task DeleteArticle(string id, CancellationToken ct) {
            context.Articles.Remove(new Article { Id = id });
            await context.SaveChangesAsync(ct);
        }

        public async Task<Article> GetArticle(string id, CancellationToken ct) {
            return await context.Articles.FirstOrDefaultAsync(x => x.Id == id, ct);
        }

        public async Task<IQueryable<Article>> GetArticles(CancellationToken ct) {
            return context.Articles;
        }

        public async Task UpdateArticle(Article article, CancellationToken ct) {
            if(await context.Articles.FindAsync(article.Id) is Article founded) {
                founded.Title = article.Title;
                founded.Description = article.Description;
                founded.Body = article.Body;
                founded.AuthorId = article.AuthorId;
                founded.CreatedAt = article.CreatedAt;
                founded.LastUpdatedAt = DateTime.UtcNow;

                await context.SaveChangesAsync();
            }
        }
    }
}
