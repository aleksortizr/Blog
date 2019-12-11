using Blog_Common.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_BusinessLogic
{
    public interface IBlogManager
    {
        public bool AddPost(PostDTO request);
    }
}
