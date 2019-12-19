using Blog.DataAccess;
using Blog_Common.DTOs;

namespace Blog_Repositories
{
    internal interface ICommentsRepository : IRepository<Comment>
    {
        public int Add(CommentDTO comment);
    }
}