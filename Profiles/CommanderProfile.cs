using AutoMapper;
using Csharp_REST_API.Dtos;
using Csharp_REST_API.Models;

namespace Csharp_REST_API.Profiles
{
    public class CommanderProfile : Profile
    {
        public CommanderProfile()
        {
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}