
using Blog.DataAccess;
using Blog_Common.DTOs;
using System.Threading.Tasks;

namespace Blog_MVC.Services
{
    public interface IUserService
    {
        Task<UserDTO> Authenticate(string userName, string password);
        Task<UserDTO> Add(string username, string password);
        public Task<bool> CreatePost(string userId, string text);
    }
}