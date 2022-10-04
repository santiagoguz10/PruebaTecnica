
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Models;

namespace PruebaTecnica.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
        }
        
        public DbSet<RouletteModel> Roulette { get; set; }  
    }
}
