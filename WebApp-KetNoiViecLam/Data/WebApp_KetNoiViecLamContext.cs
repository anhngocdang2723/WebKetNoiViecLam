using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp_KetNoiViecLam.Models;

namespace WebApp_KetNoiViecLam.Data
{
    public class WebApp_KetNoiViecLamContext : DbContext
    {
        public WebApp_KetNoiViecLamContext (DbContextOptions<WebApp_KetNoiViecLamContext> options)
            : base(options)
        {
        }

        public DbSet<WebApp_KetNoiViecLam.Models.Category> Category { get; set; } = default!;

        public DbSet<WebApp_KetNoiViecLam.Models.Blog>? Blog { get; set; }

        public DbSet<WebApp_KetNoiViecLam.Models.Job>? Job { get; set; }

        public DbSet<WebApp_KetNoiViecLam.Models.Profile>? Profile { get; set; }

        public DbSet<WebApp_KetNoiViecLam.Models.Review>? Review { get; set; }

        public DbSet<WebApp_KetNoiViecLam.Models.Service>? Service { get; set; }

        public DbSet<WebApp_KetNoiViecLam.Models.Skill>? Skill { get; set; }

        public DbSet<WebApp_KetNoiViecLam.Models.User>? User { get; set; }

    }
}
