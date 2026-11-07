namespace HomeDriveServer {
    public class Program {
        private static string? BasePath = null;
        private static string DbPath;

        public static void Main(string[] args) {
            if (!Init()) {
                Console.Write("Press any key to end this program.");
                Console.ReadKey(true);
                return;
            }

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static bool Init() {
            BasePath = Environment.ProcessPath;

            if (BasePath == null) {
                Console.WriteLine("[Error] The server path is not accessible.");
                return false;
            }

            Console.WriteLine($"[Info] The server started at {BasePath}");

            DbPath = Path.Combine(BasePath, "Db", "HomeDrive.db");

            if (!Path.Exists(DbPath)) {
                Console.WriteLine("[Info] The database was not created, creating now...");

                if (!CreateDatabase()) {
                    Console.WriteLine("[Error] Failed to create database.");
                    return false;
                }
            }

            return true;
        }

        private static bool CreateDatabase() {
            return true;
        }
    }
}
