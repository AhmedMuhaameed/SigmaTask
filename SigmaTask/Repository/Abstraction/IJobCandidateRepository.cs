using AutoMapper;
using SigmaTask.Entities.Models;
using SigmaTask.Services.DTO;

namespace SigmaTask.Repository.Abstraction
{
    public interface IJobCandidateRepository
    {
        Task<List<CandidateDTO>> GetCandidatesAsync();
        Task<CandidateDTO> GetCandidateAsync(int candidateId);
        Task<CandidateDTO> AddCandidateAsync(Candidate candidate);
        Task<CandidateDTO> UpdateCandidateAsync(Candidate candidate);
        Task DeleteCandidateAsync(int candidateId);
     
    }
}
