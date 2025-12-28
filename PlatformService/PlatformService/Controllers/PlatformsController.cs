using Microsoft.AspNetCore.Mvc;
using PlatformService.DTO;
using PlatformService.Profiles;
using PlatformService.Repository;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : Controller
    {
        private readonly IPlatformRepo _platformRepo;

        public PlatformsController(IPlatformRepo platformRepo )
        {
            _platformRepo = platformRepo;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatForms()
        {
            Console.WriteLine("--> Getting Platforms ...");

            var platformItems = _platformRepo.GetAllPlatforms();
            var platformReadDtos = platformItems.Select(p => p.ToReadDto()).ToList();
            return Ok(platformReadDtos);
        }
        
        [HttpGet("{id}", Name = "GetPlatformReadById")]
        public ActionResult<PlatformReadDto> GetPlatformReadById(int id)
        {
            var platformItem = _platformRepo.GetPlatformById(id);
            if(id != null)
            {
                var platformReadDto = platformItem.ToReadDto();
                return Ok(platformReadDto);
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatformItem(PlatformCreateDto platformCreate)
        {
            //mapping DTO to Model as our Repo is expecting model
            var platformModel = platformCreate.ToModel();
            _platformRepo.CreatePlatform(platformModel);
            _platformRepo.SaveChanges();

            //mapping model to ReadDto
            var platformReadDto = platformModel.ToReadDto();

            //return http 201 with route. route is the GetPlatformReadById as we are displaying the resource
            return CreatedAtRoute(nameof(GetPlatformReadById), new { Id = platformReadDto.PlatformId}, platformReadDto);
        }
    }
}
