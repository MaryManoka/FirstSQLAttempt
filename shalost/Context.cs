using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progect1.shalost
{
    public class Context : DbContext
    {
        public Context() 
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated(); //метод, который создает БД        

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=shalost;"); //подключение к SQLServer и создание под него БД
        }

        public DbSet<User> Users { get; set; } // таблица "Пользователи" из User.cs
        public DbSet<Role> Roles { get; set; } // таблица "Роли" из Role.cs
    }
}
