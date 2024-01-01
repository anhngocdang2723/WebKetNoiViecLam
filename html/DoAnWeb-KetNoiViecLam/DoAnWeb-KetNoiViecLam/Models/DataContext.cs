using Microsoft.EntityFrameworkCore;
using DoAnWeb_KetNoiViecLam.Models;

namespace DoAnWeb_KetNoiViecLam.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
    }
}
