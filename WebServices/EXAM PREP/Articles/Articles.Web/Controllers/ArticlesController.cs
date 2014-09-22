namespace Articles.Web.Controllers
{
    using Articles.Data;
    using Articles.Models;
    using Articles.Web.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;
    public class ArticlesController : BaseApiController
    {
        const int defaultPageSize = 2;

        // Ninject Constructor
        //public ArticlesController(IArticlesData data)
        //    :base(data)
        //{
        //}

        // Comment me if you use NINJECT
        public ArticlesController()
            : this(new ArticlesData(new ApplicationDbContext()))
        {

        }

        public ArticlesController(IArticlesData data)
            : base(data)
        {
        }
        // Comment me END

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Get(null, 0);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var article = this.data.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }

            var articleModel = new ArticlesDetailsModel(article);

            return Ok(articleModel);
        }

        [HttpGet]
        public IHttpActionResult Get(string category)
        {
            return Get(category, 0);
        }

        [HttpGet]
        public IHttpActionResult Get(int page)
        {
            return Get(null, page);
        }

        private IEnumerable<ArticleModel> GetAllSortedByDate()
        {
            return this.data.Articles.All()
                .OrderByDescending(a => a.DateCreated)
                .Select(ArticleModel.FromArticle);
        }

        [HttpGet]
        public IHttpActionResult Get(string category, int page)
        {
            var articles = GetAllSortedByDate()
                .Where(a => category !=null ? a.Category == category : true) // DO NOT WORK!
                .Skip(page * defaultPageSize)
                .Take(defaultPageSize);
            return Ok(articles);
        }


        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(ArticleModel model)
        {
            var tags = GetTags(model);
            var category = GetCategory(model.Category);
            var userId = this.User.Identity.GetUserId();

            var newArticle = new Article
            {
                Title = model.Title,
                Content = model.Content,
                CategoryId = category.Id,
                DateCreated = DateTime.Now,
                AuthorId = userId,
                Tags = tags
            };

            this.data.Articles.Add(newArticle);
            this.data.SaveChanges();

            model.Id = newArticle.Id;
            model.DateCreated = newArticle.DateCreated;
            model.Tags = newArticle.Tags.AsQueryable().Select(TagModel.FromTag).ToArray();

            return Ok(model);
        }

        private Category GetCategory(string modelCategory)
        {
            var category = this.data.Categories.All().FirstOrDefault(c => c.Name == modelCategory);
            if (category == null)
            {
                category = new Category { Name = modelCategory };
                this.data.Categories.Add(category);
            }

            return category;
        }

        private ICollection<Tag> GetTags(ArticleModel model)
        {
            var titleTags = model.Title.Split(' ');
            var allTags = new HashSet<string>(titleTags);

            foreach (var modelTag in model.Tags)
            {
                allTags.Add(modelTag.Name);
            }

            var articleTags = new HashSet<Tag>();
            foreach (var tagName in allTags)
            {
                var tag = this.data.Tags.All()
                    .FirstOrDefault(t => t.Name == tagName);
                if (tag == null)
                {
                    tag = new Tag { Name = tagName };
                    this.data.Tags.Add(tag);
                }

                articleTags.Add(tag);
            }

            return articleTags;
        }



    }
}
