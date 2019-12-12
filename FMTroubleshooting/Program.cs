using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner.Processors.SqlServer;

namespace FMTroubleshooting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var announcer = new ConsoleAnnouncer();

            // Processor specific options (usually none are needed)
            var options = new ProcessorOptions();

            var processorFactory = new SqlServerProcessorFactory();

            // Initialize the processor
            using (var processor = processorFactory.Create(
                "server=(local);database=testDatabase;user=testUser;password=testPassword",
                announcer,
                options))
            {
                // Configure the runner
                var context = new RunnerContext(announcer)
                {
                    ApplicationContext = "some value"
                };

                // Create the migration runner
                var runner = new MigrationRunner(
                    // Specify the assembly with the migrations
                    typeof(Program).Assembly,
                    context,
                    processor);

                // Run the migrations
                runner.MigrateUp();
            }
        }
    }
}
