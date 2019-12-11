using Blog.DataAccess;
using LinqToDB.Data;

namespace Blog_Repositories
{
    public class UserRepository : BaseRepository<User>, IRepository<User>, IUsersRepository
    {
        public UserRepository(DataConnection context) : base(context)
        {

        }
    }
}
