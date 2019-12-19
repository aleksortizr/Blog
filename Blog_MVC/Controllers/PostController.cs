using Blog_MVC.Models;
using Blog_MVC.Services;
using LinqToDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blog_MVC.Controllers
{
    [Route("[controller]")]
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostManagerService _postManagerService;
        private readonly IDataContext _context;

        public PostController(ILogger<PostController> logger, IPostManagerService userService, IDataContext context)
        {
            _context = context;
            _postManagerService = userService;
            _logger = logger;
        }
        
        [Authorize]
        public IActionResult CreatePost()
        {
            return View(new PostModel());
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreatePost(PostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userName = User.Claims.First(x => x.Type == ClaimTypes.Name).Value;

            if (!await _postManagerService.CreatePost(userName, model.Text))
            {
                ModelState.AddModelError("Error creating the post", "Could not validate your credentials");
                return View(model);
            }

            return RedirectToAction("Index", "UserPosts");
        }

        [Route("approvedposts")]
        [AllowAnonymous]
        public IActionResult ApprovedPosts()
        {
            var userPosts = _postManagerService.ApprovedPosts().Result;
            return View(new EditorPostsModel { UserName = "Anonymous", UserPosts = userPosts});
        }
    }
}