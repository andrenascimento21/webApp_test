using DataModel;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService: IUserService
    {
        public List<User> GetAll()
        {
            using (var context = new DataContext())
            {
                return context.Users.ToList();
            }
        }

        public User Get(int id)
        {
            using (var context = new DataContext())
            {
                return context.Users.FirstOrDefault(x => x.Id == id);
            }
        }

        public void Update(User u)
        {
            using (var context = new DataContext())
            {
                var user = context.Users.FirstOrDefault(x => x.Id == u.Id);
                if(user != null)
                {
                    user.Name = u.Name;
                    user.Address = u.Address;

                    context.SaveChanges();
                }
            }
        }

        public void Add(User user)
        {
            using (var context = new DataContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new DataContext())
            {
                var user = context.Users.FirstOrDefault(x => x.Id == id);
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
        }
    }
}
