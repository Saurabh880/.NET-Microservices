using PlatformService.DTO;
using PlatformService.Model;

namespace PlatformService.Profiles
{
    public static class PlatformMappings
    {
        public static Platform ToModel(this PlatformCreateDto dto)
        {
            return new Platform
            {
                Name = dto.Name,
                Publisher = dto.Publisher,
                Cost = dto.Cost
            };
        }

        public static PlatformReadDto ToReadDto(this Platform model)
        {
            return new PlatformReadDto
            {
                PlatformId = model.PlatformId,
                Name = model.Name,
                Publisher = model.Publisher,
                Cost = model.Cost
            };
        }
        public static void ApplyTo(this PlatformCreateDto dto, Platform model)
        {
            model.Name = dto.Name;
            model.Publisher = dto.Publisher;
            model.Cost = dto.Cost;
        }
    }
}
