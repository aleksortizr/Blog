using Blog_Common.DTOs;

namespace Blog_Repositories
{
    public interface IPostsRepository
    {
        public bool Add(PostDTO post);

        public bool Approve(int postId);

        public bool Reject(int postId);

        public bool Delete(int postId);
    }
}
