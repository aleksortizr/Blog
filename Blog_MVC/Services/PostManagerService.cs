using Blog.DataAccess;
using Blog_BusinessLogic;
using Blog_BusinessLogic.Services;
using Blog_Common.DTOs;
using Blog_Common.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blog_MVC.Services
{
    public class PostManagerService : IPostManagerService
    {
        private readonly IBlogUserManager _blogUserManager;
        private readonly IBlogManager _blogManager;

        public PostManagerService(IBlogUserManager blogUserManager, IBlogManager blogManager)
        {
            _blogUserManager = blogUserManager;
            _blogManager = blogManager;
        }

        public Task<UserDTO> Add(string userName, string password)
        {
            if (_blogUserManager.UserExists(userName))
            {
                throw new InvalidOperationException("Username already in use");
            }

            var newUser = new UserDTO
            {
                UserName = userName,
                Password = password,
                RoleId = 1
            };

            if (_blogUserManager.Register(newUser) > 0)
                return Task.FromResult(newUser);
            return null;
        }
        public Task<UserDTO> Authenticate(string userName, string password)
        {
            return Task.FromResult(_blogUserManager.Authenticate(new Blog_Common.Requests.AuthenticationRequest
            {
                UserName = userName,
                Password = password
            }));
        }

        public Task<bool> CreatePost(string username, string text)
        {
            return Task.FromResult(_blogManager.AddPost(new CreatePostRequest
            {
                Text = text,
                UserName = username
            }));
        }

        public Task<IEnumerable<PostDTO>> UserPosts(string userId)
        {
            return Task.FromResult(_blogManager.GetUserPosts(userId));
        }

        #region Private Methods
        private string HashString(string str)
        {
            var message = Encoding.Unicode.GetBytes(str);
            var hash = new SHA256Managed();

            var hashValue = hash.ComputeHash(message);
            return Encoding.Unicode.GetString(hashValue);
        }

        #endregion

    }
}