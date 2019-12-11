using Blog_Common.DTOs;
using Blog_Repositories;

namespace Blog_BusinessLogic
{
    public class BlogManager : IBlogManager
    {
        private readonly IPostsRepository _postsRepository;
        private readonly IUsersRepository _usersRepository;

        public BlogManager(IPostsRepository postRepository, IUsersRepository userRepository)
        {
            _postsRepository = postRepository;
            _usersRepository = userRepository;
        }

        public bool AddPost(PostDTO request)
        {
            _postsRepository.Add(request);
            return true;  
        }
    }
}
