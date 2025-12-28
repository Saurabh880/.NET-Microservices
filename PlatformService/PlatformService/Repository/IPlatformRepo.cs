using PlatformService.Model;

namespace PlatformService.Repository
{
    public interface IPlatformRepo
    {
        bool SaveChanges();

        void CreatePlatform(Platform plat);
        Platform GetPlatformById(int platformId);
        IEnumerable<Platform> GetAllPlatforms();
    }
}
