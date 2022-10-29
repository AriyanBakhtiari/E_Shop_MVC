using E_Shop.Models;
using E_Shop.Data;
using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks.Dataflow;

namespace E_Shop.Repository
{
    public interface IUserRepository
    {
        bool IsEmailValids(string email);
        void AddUser(Users user);
        double GetWalletUser(string email );

        Users GetUser(string email , string password);
    }


    public class UserRepository : IUserRepository
    {
        private EShopContext _context;
        public UserRepository(EShopContext context)
        {
            _context = context;
        }

        public bool IsEmailValids(string email)
        {
            return _context.Users.Any(e => e.Email == email);
        }

        public void AddUser(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public Users GetUser(string email, string password)
        {
            return _context.Users
                .SingleOrDefault(w=> w.Email == email && w.Password == password);
        }

        public double GetWalletUser(string email)
        {
            return _context.Users.SingleOrDefault(w => w.Email == email).Wallet;
        }
    }
}
