using Blog_Common.DTOs;
using Blog_Repositories;
using System.Collections.Generic;

namespace Blog_BusinessLogic
{
    public class BlogManager : IBlogManager
    {
        private readonly IPostsRepository _postsRepository;
        //private readonly IUsersRepository _usersRepository;

        public BlogManager(IPostsRepository postRepository
            //, IUsersRepository userRepository
            )
        {
            _postsRepository = postRepository;
            //_usersRepository = userRepository;
        }

        public bool Add(PostDTO request)
        {
            _postsRepository.Add(request);
            return true;
        }

        public IEnumerable<PostDTO> Get(int? postId)
        {
            if (postId.HasValue)
            {
                var result = _postsRepository.Get(postId.Value);
                return Mapping.Mapper.Map<IEnumerable<PostDTO>>(result);
            }

            return Mapping.Mapper.Map<IEnumerable<PostDTO>>(_postsRepository.Get());
        }
    }
}

