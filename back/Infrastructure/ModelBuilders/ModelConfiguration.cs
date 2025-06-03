using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ModelBuilders;
internal static class ModelConfiguration
{
    internal static ModelBuilder Configure(this ModelBuilder modelBuilder)
    {
        modelBuilder.User();

        return modelBuilder;
    }
}
