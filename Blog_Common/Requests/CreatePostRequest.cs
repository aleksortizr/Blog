using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_Common.Requests
{
    public class CreatePostRequest
    {
        public int UserId { get; set; }

        public string Text { get; set; }

    }
}
