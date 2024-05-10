using SigmaTask.Services.Abstraction;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SigmaTask.Services.DTO;
using SigmaTask.Repository.Abstraction;
using SigmaTask.Entities.Models;
namespace SigmaTask.Services.Implmentation
{
    public class JobCandidateService : IJobCandidateService
    {
        private readonly IMapper mapper;
        private readonly IJobCandidateRepository jobCandidateRepository;

        public JobCandidateService(IJobCandidateRepository jobCandidateRepository)
        {
            this.jobCandidateRepository = jobCandidateRepository;
        }

        public async Task<ResponseDTO<List<CandidateDTO>>> GetCandidatesAsync()
        {
            var result = await this.jobCandidateRepository.GetCandidatesAsync();
            return ResponseDTO<List<CandidateDTO>>.Success(result, "Candidates Fetched Successfully");
        }

        public async Task<ResponseDTO<CandidateDTO>> GetCandidateAsync(int candidateId)
        {
            var result = await this.jobCandidateRepository.GetCandidateAsync(candidateId);
            return ResponseDTO<CandidateDTO>.Success(result, "Candidate Fetched Successfully");
        }

        public async Task<ResponseDTO<CandidateDTO>> AddCandidateAsync(AddCandidateDTO candidateDTO)
        {
            var candidateEntity = this.mapper.Map<Candidate>(candidateDTO);
            try
            {
                var result = await this.jobCandidateRepository.AddCandidateAsync(candidateEntity);
                return ResponseDTO<CandidateDTO>.Success(result, "Candidate Added Successfully");

            }
            catch (Exception ex)
            {
                return ResponseDTO<CandidateDTO>.Fail("Cannot Add Candidate");
            }
        }

        public async Task<ResponseDTO<CandidateDTO>> UpdateCandidateAsync(CandidateDTO candidateDTO)
        {
            var candidateEntity = this.mapper.Map<Candidate>(candidateDTO);
            try
            {
                var result = await this.jobCandidateRepository.UpdateCandidateAsync(candidateEntity);
                return ResponseDTO<CandidateDTO>.Success(result, "Candidate Updated Successfully");

            }
            catch (Exception ex)
            {
                return ResponseDTO<CandidateDTO>.Fail("Cannot Update Candidate");
            }
        }

        public async Task<EmptyResponse> DeleteCandidateAsync(int  candidateId)
        {
            try
            {
                await this.jobCandidateRepository.DeleteCandidateAsync(candidateId);
                return EmptyResponse.Success("Candidate Deleted Successfully");

            }
            catch (Exception ex)
            {
                return EmptyResponse.Fail("Cannot Delete Candidate");
            }
        }
    }
}
