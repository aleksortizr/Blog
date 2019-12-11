using Blog.DataAccess;
using Blog_Common;
using Blog_Common.DTOs;
using LinqToDB.Data;
using System;

namespace Blog_Repositories
{
    public class PostsRepository : BaseRepository<Post>, IRepository<Post>, IPostsRepository
    {
        public PostsRepository(DataConnection context) : base(context)
        {

        }

        public bool Add(PostDTO post)
        {
            var result = Add(new Post
            {
                CreatedDate = DateTime.Now,
                StatusId = (int)PostStatuses.Pending,
                Text = post.Text,
                UserId = post.UserId
            });

            return String.IsNullOrEmpty(result);
        }

        public bool Approve(int postId)
        {
            throw new NotImplementedException();
        }

        public bool ApprovePost(int postId)
        {
            Post post = FindById(postId);

            if(post != null)
            {
                post.StatusId = (int)PostStatuses.Approved;
                return Update(post);
            }
            return false;
        }

        public bool Reject(int postId)
        {
            throw new NotImplementedException();
        }

        public bool RejectPost(int postId)
        {
            Post post = FindById(postId);

            if (post != null)
            {
                post.StatusId = (int)PostStatuses.Rejected;
                return Update(post);
            }
            return false;
        }

        bool IPostsRepository.Delete(int postId)
        {
            return Delete(postId);
        }
    }
}
