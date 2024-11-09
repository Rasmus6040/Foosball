using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BusinessLogic.Data.Contexts;

public class EloSystemContextFactory : IDesignTimeDbContextFactory<EloSystemContext>
{
    public EloSystemContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EloSystemContext>();
        optionsBuilder.UseSqlite("DataSource=EloSystem.db");
        return new EloSystemContext(optionsBuilder.Options);
    }
}