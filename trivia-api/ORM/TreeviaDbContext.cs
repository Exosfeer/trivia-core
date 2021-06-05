using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trivia_api.Models;

namespace trivia_api.ORM
{
    public class TreeviaDbContext : DbContext
    {
        //constructor
        public TreeviaDbContext(DbContextOptions<TreeviaDbContext> options) : base(options)
        {

        }

        public DbSet<Account> Account { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Question> Question { get; set; }

    }
}
