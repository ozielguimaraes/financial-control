using FinancialControl.Infra.CrossCutting.Security.DatabaseFlavor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static FinancialControl.Infra.CrossCutting.Security.ProviderConfiguration;

namespace FinancialControl.Infra.CrossCutting.Security
{
    public static class ProviderSelector
    {
        public static IServiceCollection ConfigureProviderForContext<TContext>(
            this IServiceCollection services,
            (DatabaseType, string) options) where TContext : DbContext
        {
            var (database, connString) = options;
            Build(connString);
            return database switch
            {
                DatabaseType.SqlServer => services.PersistStore<TContext>(With.SqlServer),
                //DatabaseType.MySql => services.PersistStore<TContext>(With.MySql),
                DatabaseType.Postgre => services.PersistStore<TContext>(With.Postgre),
                DatabaseType.Sqlite => services.PersistStore<TContext>(With.Sqlite),

                _ => throw new ArgumentOutOfRangeException(nameof(database), database, null)
            };
        }

        public static Action<DbContextOptionsBuilder> WithProviderAutoSelection((DatabaseType, string) options)
        {
            var (database, connString) = options;
            Build(connString);
            return database switch
            {
                DatabaseType.SqlServer => With.SqlServer,
                //DatabaseType.MySql => With.MySql,
                DatabaseType.Postgre => With.Postgre,
                DatabaseType.Sqlite => With.Sqlite,

                _ => throw new ArgumentOutOfRangeException(nameof(database), database, null)
            };
        }

    }
}
