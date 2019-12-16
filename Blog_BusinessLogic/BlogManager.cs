using Blog_BusinessLogic.Services;
using Blog_Common;
using Blog_Common.DTOs;
using Blog_Common.Requests;
using Blog_Repositories;
using System;
using System.Collections.Generic;

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
        
        /// <summary>
        /// Checks availabilty to crate post and does the creation uppon result
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool AddPost(CreatePostRequest request)
        {
            var user = _usersRepository.Get(request.UserId);
            if(user != null && user.RoleId == (int) Roles.Writer)
            {
                var insertedId = _postsRepository.Add(new PostDTO
                {
                    CreatedDate = DateTime.Now,
                    StatusId = (int) PostStatuses.Created,
                    Text = request.Text,
                    UserId = request.UserId
                });

                return insertedId > 0;
            }

            return false;
        }

        public IEnumerable<PostDTO> GetPosts(int? postId)
        {
            if (postId.HasValue)
            {
                var result = _postsRepository.Get(postId.Value);
                return Mapping.Mapper.Map<IEnumerable<PostDTO>>(result);
            }

            return Mapping.Mapper.Map<IEnumerable<PostDTO>>(_postsRepository.Get());
        }

        public bool EditPost(UpdatePostRequest request)
        {
            var updatingPost = _postsRepository.Get(request.PostId);

            if(updatingPost != null && (updatingPost.StatusId == (int) PostStatuses.Rejected || updatingPost.StatusId == (int)PostStatuses.Created))
            {
                updatingPost.Text = request.Text;
                return _postsRepository.Update(updatingPost);
            }

            return false;
        }

        public bool SubmitPost(int postId)
        {
            var updatingPost = _postsRepository.Get(postId);

            if (updatingPost != null && (updatingPost.StatusId == (int)PostStatuses.Rejected || updatingPost.StatusId == (int)PostStatuses.Created))
            {
                return _postsRepository.ChangeStatus(postId, PostStatuses.Pending);
            }

            return false;
        }

        public bool ApprovePost(int postId)
        {
            var updatingPost = _postsRepository.Get(postId);

            if (updatingPost != null && updatingPost.StatusId == (int)PostStatuses.Pending)
            {
                return _postsRepository.ChangeStatus(postId, PostStatuses.Approved);
            }

            return false;
        }

        public bool RejectPost(int postId)
        {
            var updatingPost = _postsRepository.Get(postId);

            if (updatingPost != null && updatingPost.StatusId == (int)PostStatuses.Pending)
            {
                return _postsRepository.ChangeStatus(postId, PostStatuses.Rejected);
            }

            return false;
        }

        public bool DeletePost(int postId)
        {
            var deletingPost = _postsRepository.Get(postId);

            if (deletingPost != null)
            {
                return _postsRepository.Delete(postId);
            }

            return false;
        }
    }
}

