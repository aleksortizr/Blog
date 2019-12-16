using Blog_Common.DTOs;
using Blog_Common.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_BusinessLogic.Services
{
    public interface IBlogManager
    {
        public bool AddPost(CreatePostRequest request);

        public IEnumerable<PostDTO> GetPosts(int? postId);

        public bool EditPost(UpdatePostRequest request);

        public bool DeletePost(int postId);

        public bool SubmitPost(int postId);

        public bool ApprovePost(int postId);

        public bool RejectPost(int postId);
    }
}
