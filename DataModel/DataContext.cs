using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class DataContext: DbContext
    {
        public DataContext(): base("WebApp") { }

        public DbSet<User> Users { get; set; }
    }
}
