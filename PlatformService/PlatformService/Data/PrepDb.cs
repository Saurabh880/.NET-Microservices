using PlatformService.Model;

namespace PlatformService.Data
{
    public class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder builder)
        {
            //Video Timestamp 1:19:00 
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("<----Seeding Data----->");

                context.Platforms.AddRange(
                    new Platform() { Name = "Dot Net",Publisher="Microsoft", Cost="Free" },
                    new Platform() { Name = "SQL Server", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing foundation", Cost = "Free" },
                    new Platform() { Name = "Docker", Publisher = "Docker Inc", Cost = "Free" }
                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("We have data already");
            }
        }
    }
}
