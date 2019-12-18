using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blog_MVC.Models;
using Blog_MVC.Services;
using LinqToDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Blog_MVC.Controllers
{
    public class UserPostsController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IPostManagerService _postManagerService;
        private readonly IDataContext _context;

        public UserPostsController(ILogger<PostController> logger, IPostManagerService userService, IDataContext context)
        {
            _context = context;
            _postManagerService = userService;
            _logger = logger;
        }

        [Route("userposts")]
        [Authorize]
        public IActionResult Index()
        {
            var userName = User.Claims.First(x => x.Type == ClaimTypes.Name).Value;
            var userPosts = _postManagerService.UserPosts(userName);
            return View(new UserPostsModel { UserName = userName, UserPosts = userPosts.Result });
        }

        [Route("Edit")]
        [Authorize]
        [HttpPost]
        public ActionResult Edit(int postId)
        {
            return View();
        }
    }
}