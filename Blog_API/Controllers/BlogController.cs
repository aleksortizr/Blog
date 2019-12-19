using Blog_BusinessLogic;
using Blog_BusinessLogic.Services;
using Blog_Common.DTOs;
using Blog_Common.Requests;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
        public PostDTO Get(int postId)
        {
            return _blogManager.GetPost(postId); 
        }

        [HttpPost]
        public bool Post([FromBody] CreatePostRequest request)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    return _blogManager.AddPost(request);
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, $"Error creating post.", null);
                }
            }
            
            return false;
        }

        [HttpPut] 
        public bool Put([FromBody] UpdatePostRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return _blogManager.EditPost(request);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error editing post.", null);
                }
            }

            return false;
        }

        [HttpDelete]
        public bool Delete(int postId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return _blogManager.DeletePost(postId);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error editing post.", null);
                }
            }

            return false;
        }
    }
}