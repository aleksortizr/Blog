using Blog_BusinessLogic;
using Blog_Common.DTOs;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Blog_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ILogger<BlogController> _logger;
        private readonly IBlogManager _blogManager;
        private readonly IDataContext _context;

        public BlogController(ILogger<BlogController> logger, IBlogManager blogManager, IDataContext context)
        {
            _context = context;
            _logger = logger;
            _blogManager = blogManager;
        }

        [HttpGet]
        public IEnumerable<PostDTO> Get(int? postId)
        {
            var result = _blogManager.Get(postId);
            return result;
        }
    }
}