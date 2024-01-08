using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using WebApp_KetNoiViecLam.Data;

public class WebApp_KetNoiViecLamContextFactory : IDesignTimeDbContextFactory<WebApp_KetNoiViecLamContext>
{
    public WebApp_KetNoiViecLamContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<WebApp_KetNoiViecLamContext>();
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WebApp_KetNoiViecLam.Data;Trusted_Connection=True;MultipleActiveResultSets=true");

        return new WebApp_KetNoiViecLamContext(optionsBuilder.Options);
    }
}