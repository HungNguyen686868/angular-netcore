using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using multipleTable.Models;

namespace multipleTable.Data
{

    public class MultipleTableDbContext : DbContext
    {
        public MultipleTableDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { set; get; }

        public DbSet<Category> Categories { set; get; }


    }
}
