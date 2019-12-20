using Blog_Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog_MVC.Models
{
    public class CommentPostModel
    {
        public PostDTO Post { get; set; }

        public int? UserId { get; set; }

        public string UserName { get; set; }

        public string Text { get; set; }
    }
}
