using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksLaba
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base ("DbConnectionString")
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
