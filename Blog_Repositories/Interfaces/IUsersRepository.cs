using Blog.DataAccess;
using Blog_Common.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog_Repositories
{
    public interface IUsersRepository : IRepository<User>
    {
        public UserDTO Get(int userId);

        public IEnumerable<UserDTO> Get();

    }
}
