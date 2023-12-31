using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using wapi.Domain;
using wapi.Domain.Entities;
using wapi.Domain.Entities.Idenity;
using wapi.Models;

namespace wapi.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController: ControllerBase {

        private readonly DataManager dataManager;
        private readonly UserManager<AppUser> userManager;
        private readonly ILogger _logger;
        public ArticleController(DataManager dataManager, UserManager<AppUser> userManager, ILogger<ArticleController> logger) {
            this.userManager = userManager;
            this.dataManager = dataManager;
            this._logger = logger;
        }

        [HttpPost("Create")]
        [Authorize]
        public async Task<IActionResult> CreateArticle([FromBody] ArticleModel model, CancellationToken ct) {

            var user = await userManager.FindByNameAsync(this.User.Identity.Name);
            var res = new Article() {
                Id = Guid.NewGuid().ToString(),
                Title = model.Title,
                Description = model.Description,
                Body = model.Body,
                CreatedAt = DateTime.UtcNow,
                LastUpdatedAt = DateTime.UtcNow,
                AuthorId = user.Id,
            };

            await dataManager.Articles.CreateArticle(res);

            return Ok(new Response { Status = "Success", Message = "Article created successfully!" });
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetArticles(CancellationToken ct) {
            var res = await dataManager.Articles.GetArticles();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticleById(string id, CancellationToken ct) {
            var res = await dataManager.Articles.GetArticle(id);

            return Ok(res);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateArticle(string id, [FromBody] ArticleModel model, CancellationToken ct) {

            var res = await dataManager.Articles.GetArticle(id);
            res.Title = model.Title;
            res.Description = model.Description;
            res.Body = model.Body;

            await dataManager.Articles.UpdateArticle(res);

            return Ok(new Response { Status = "Success", Message = "Article updated successfully!" });
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteArticle(string id, CancellationToken ct) {
            await dataManager.Articles.DeleteArticle(id);
            return Ok(new Response { Status = "Success", Message = "Article deleted successfully!" });
        }
    }
}
