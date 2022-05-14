using Models;
using Repository;

namespace Srevices
{
    public class UsersService
    {
        private Context _context;

        public UsersService()
        {
            _context = new Context();   
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User.ToList();
        }

    }
}