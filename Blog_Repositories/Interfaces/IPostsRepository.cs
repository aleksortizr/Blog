using Blog_Common.DTOs;
using System.Collections.Generic;

namespace Blog_Repositories
{
    public interface IPostsRepository
    {
        public bool Add(PostDTO post);

        public bool Approve(int postId);

        public bool Reject(int postId);

        public bool Delete(int postId);

        public PostDTO Get(int? postId);

        public IEnumerable<PostDTO> Get();
    }
}
