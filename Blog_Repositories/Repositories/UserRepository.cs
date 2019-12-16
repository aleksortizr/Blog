using Blog.DataAccess;
using Blog_Common.DTOs;
using LinqToDB;
using LinqToDB.Data;
using System.Collections.Generic;

namespace Blog_Repositories
{
    public class UserRepository : BaseRepository<User>, IRepository<User>, IUsersRepository
    {
        public UserRepository(IDataContext context) : base(context)
        {
            
        }

        public UserDTO Get(int postId)
        {
            var result = FindById(postId);
            return Mapping.Mapper.Map<UserDTO>(result);
        }

        public IEnumerable<UserDTO> Get()
        {
            var result = List(null, null);
            return Mapping.Mapper.Map<IEnumerable<UserDTO>>(result);
        }
    }
}
