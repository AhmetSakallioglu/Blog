using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class PostController : Controller
    {
        private IPostRepository _postrepository;

		public PostController(IPostRepository postRepository)
		{
			_postrepository = postRepository;
		}

		public IActionResult Index()
        {
            return View(
                new PostViewModel
                {
                    Posts = _postrepository.Posts.ToList(),
                }
                );
        }
    }
}
