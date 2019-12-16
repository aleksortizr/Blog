using Blog.DataAccess;
using Blog_Common.DTOs;
using LinqToDB;
using LinqToDB.Data;
using System.Collections.Generic;
using System.Linq;

namespace Blog_Repositories
{
    public class UserRepository : BaseRepository<User>, IRepository<User>, IUsersRepository
    {
        public UserRepository(IDataContext context) : base(context)
        {
            
        }

        public UserDTO Get(int userId)
        {
            var result = FindById(userId);
            return Mapping.Mapper.Map<UserDTO>(result);
        }

        public UserDTO Get(string userName)
        {
            var result = _dbSet.Where(u => u.UserName.Equals(userName, System.StringComparison.InvariantCultureIgnoreCase));
            if (result == null)
                return null;
            return Mapping.Mapper.Map<UserDTO>(result);
        }

        public IEnumerable<UserDTO> Get()
        {
            var result = List(null, null);
            return Mapping.Mapper.Map<IEnumerable<UserDTO>>(result);
        }

        public int Register(UserDTO request)
        {
            return Add(new User
            {
                Password = request.Password,
                RoleId = 1,
                UserName = request.UserName
            });
        }
    }
}
