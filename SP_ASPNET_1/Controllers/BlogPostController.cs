using SP_ASPNET_1.DbFiles.Operations;
using SP_ASPNET_1.Models;
using SP_ASPNET_1.ViewModels;
using System.Web.Mvc;
using System.Web.Routing;
using SP_ASPNET_1.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SP_ASPNET_1.Controllers
{
    [RoutePrefix("Blog")]
    public class BlogPostController : Controller
    {
        private readonly BlogPostOperations _blogPostOperations = new BlogPostOperations();

        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {
            //return this.View();
            var page = Convert.ToInt32(HttpContext.Session["Page"]) + 1;
            BlogIndexViewModel result = this._blogPostOperations.GetBlogIndexViewModel(page);
            HttpContext.Session["Page"] = Convert.ToString(page);
            ViewBag.Title = "Blog";
            return View(result);
        }

        [Route("Detail/{id:int?}")]
        [HttpGet]
        public ActionResult SinglePost(int? id)
        {
            ViewBag.Title = "single post";

            
            BlogSinglePostViewModel modelView;

            if (id == null)
            {
                modelView = this._blogPostOperations.GetLatestBlogPost();
            }
            else
            {
                modelView = this._blogPostOperations.GetBlogPostByIdFull((int)id);
            }

            return View(modelView);
        }

        [Route("Detail/Random")]
        [HttpGet]
        public ActionResult RandomPost()
        {
            ViewBag.Title = "Random post";

            var viewModel = this._blogPostOperations.GetRandomBlogPost();

            return View(viewModel);
        }

        [Route("LatestPost")]
        [HttpGet]
        public ActionResult LatestPost()
        {
            var viewModel = this._blogPostOperations.GetLatestBlogPost();

            return this.PartialView("~/Views/BlogPost/_BlogPostRecentPartialView.cshtml", viewModel);
        }

        [Route("Create")]
        [HttpPost]
        public ActionResult Create(BlogPost blogPost)
        {
            try
            {
                this._blogPostOperations.Create(blogPost);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Route("Edit/{id:int?}")]
        [HttpGet]
        public ActionResult EditBlogPost(int id)
        {
            BlogPost blogPost;

            blogPost = this._blogPostOperations.GetBlogPostByIdD((int)id);

            return View(blogPost);
        }

        [Route("Edit/{id:int}")]
        [HttpPost]
        public ActionResult Edit(BlogPost blogPost)
        {
            try
            {
                this._blogPostOperations.Update(blogPost);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Route("Delete/{id:int}")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                this._blogPostOperations.Delete(id);

                //CHECK: should return to blogs
                return RedirectToAction("../Blog");
            }
            catch
            {
                return this.HttpNotFound();
            }
        }
    }
}
