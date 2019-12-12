using Blog.DataAccess;
using Blog_Common;
using Blog_Common.DTOs;
using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;

namespace Blog_Repositories
{
    public class PostsRepository : BaseRepository<Post>, IRepository<Post>, IPostsRepository
    {
        public PostsRepository(IDataContext context) : base(context)
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

        public PostDTO Get(int postId)
        {
            var result = FindById(postId);
            return Mapping.Mapper.Map<PostDTO>(result);
        }

        public IEnumerable<PostDTO> Get()
        {
            var result = List(null, null);
            return Mapping.Mapper.Map<IEnumerable<PostDTO>>(result);
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

        PostDTO IPostsRepository.Get(int? postId)
        {
            throw new NotImplementedException();
        }
    }
}
