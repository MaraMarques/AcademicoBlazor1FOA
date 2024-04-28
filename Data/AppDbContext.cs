using BlazorApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Instituicao> Instituicoes { get; set;}
        public virtual DbSet<Departamento> Departamentos { get; set;}
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
