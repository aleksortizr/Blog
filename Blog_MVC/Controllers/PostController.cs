using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog_MVC.Models;
using Blog_MVC.Services;
using LinqToDB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Blog_MVC.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IUserService _userService;
        private readonly IDataContext _context;

        public PostController(ILogger<PostController> logger, IUserService userService, IDataContext context)
        {
            _context = context;
            _userService = userService;
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [Route("createpost")]
        public IActionResult CreatePost()
        {
            return View(new PostModel());
        }

        [Authorize]
        [Route("createpost")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> CreatePost(PostModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var some = User.Claims;

            if (!await _userService.CreatePost(some.ElementAt(1).Value, model.Text))
            {
                ModelState.AddModelError("Error creating the post", "Could not validate your credentials");
                return View(model);
            }

            return Ok();
        }
    }
}