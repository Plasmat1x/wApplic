using System.ComponentModel.DataAnnotations;

namespace wapi.Models {
    public class ArticleModel {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Body is Required")]
        public string Body { get; set; }
    }
}
