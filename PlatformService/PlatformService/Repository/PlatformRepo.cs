using PlatformService.Data;
using PlatformService.Model;

namespace PlatformService.Repository
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _appDbContext;
        public PlatformRepo(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }
        public void CreatePlatform(Platform plat)
        {
            if(plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }
            _appDbContext.Platforms.Add(plat);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _appDbContext.Platforms.ToList();
        }

        public Platform GetPlatformById(int platformId)
        {
            return _appDbContext.Platforms.FirstOrDefault(id => id.PlatformId == platformId);
        }

        public bool SaveChanges()
        {
            return (_appDbContext.SaveChanges() >= 0 );
        }
    }
}
