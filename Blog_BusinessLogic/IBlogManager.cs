using Blog_Common.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_BusinessLogic
{
    public interface IBlogManager
    {
        public bool Add(PostDTO request);

        public IEnumerable<PostDTO> Get(int? postId);
    }
}
