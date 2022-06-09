using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoTask.DataAccess.Models;
using ToDoTask.DataAccess.ModelsConfiguration;

namespace ToDoTask.DataAccess.Contexts
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ToDoConfiguration().Configure(modelBuilder.Entity<ToDoModel>());
        }


        public DbSet<ToDoModel> ToDos { get; set; }
    }
}
