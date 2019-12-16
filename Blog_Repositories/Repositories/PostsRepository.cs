﻿using Blog.DataAccess;
using Blog_Common;
using Blog_Common.DTOs;
using LinqToDB;
using System;
using System.Collections.Generic;

namespace Blog_Repositories
{
    public class PostsRepository : BaseRepository<Post>, IRepository<Post>, IPostsRepository
    {
        public PostsRepository(IDataContext context) : base(context)
        {

        }

        public int Add(PostDTO post)
        {
            return Add(new Post
            {
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                StatusId = (int)PostStatuses.Pending,
                Text = post.Text,
                UserId = post.UserId
            });
        }

        public bool Update(PostDTO post)
        {
            return Update(new Post
            {
                Id = post.Id,
                CreatedDate = post.CreatedDate,
                StatusId = (int) PostStatuses.Created,
                Text = post.Text,
                UserId = post.UserId,
                UpdatedDate = DateTime.Now
            });
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

        public bool ChangeStatus(int postId, PostStatuses status)
        {
            Post post = FindById(postId);

            if (post != null)
            {
                post.StatusId = (int)status;
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
