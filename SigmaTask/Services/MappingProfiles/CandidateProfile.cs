using AutoMapper;
using SigmaTask.Entities.Models;
using SigmaTask.Services.DTO;

namespace SigmaTask.Services.MappingProfiles
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile()
        {
            CreateMap<CandidateDTO, Candidate>().ReverseMap();
            CreateMap<AddCandidateDTO, Candidate>().ReverseMap();

        }
    }
}
