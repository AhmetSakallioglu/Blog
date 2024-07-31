using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.ViewComponents
{
	public class NewPosts : ViewComponent
	{
		private readonly IPostRepository _postRepository;

		public NewPosts(IPostRepository postRepository)
		{
			_postRepository = postRepository;
		}

		public IViewComponentResult Invoke()
		{
			return View(
				_postRepository.Posts.ToList()
				);
		}
	}
}
