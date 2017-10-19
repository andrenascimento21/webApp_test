using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService
    {
        List<User> GetAll();
        void Add(User user);
        User Get(int id);
        void Update(User u);
        void Delete(int id);
    }
}
