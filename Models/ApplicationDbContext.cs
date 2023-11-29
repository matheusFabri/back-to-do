using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using AtletaBackend.Models;

namespace AtletaApi.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Tarefa> Tarefas { get; set; } = null!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source=app.db;Cache=Shared");
        }
    }
}