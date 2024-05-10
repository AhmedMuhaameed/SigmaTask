using SigmaTask.Entities.Models;
using SigmaTask.Services.DTO;

namespace SigmaTask.Services.Abstraction
{
    public interface IJobCandidateService
    {
        Task<ResponseDTO<List<CandidateDTO>>> GetCandidatesAsync();

        Task<ResponseDTO<CandidateDTO>> GetCandidateAsync(int candidateId);

        Task<ResponseDTO<CandidateDTO>> AddCandidateAsync(AddCandidateDTO candidateDTO);


        Task<ResponseDTO<CandidateDTO>> UpdateCandidateAsync(CandidateDTO candidateDTO);


        Task<EmptyResponse> DeleteCandidateAsync(int candidateId);

    }
}
