using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SigmaTask.Domain;
using SigmaTask.Entities.Models;
using SigmaTask.Repository.Abstraction;
using SigmaTask.Services.DTO;

namespace SigmaTask.Repository.Implmentation
{
    public class JobCandidateRepository : IJobCandidateRepository
    {
        private readonly SigmaDBContext context;
        private readonly IMapper mapper;

        public JobCandidateRepository(SigmaDBContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<CandidateDTO>> GetCandidatesAsync()
        {
            var candidates = await context.Candidates.ProjectTo<CandidateDTO>(mapper.ConfigurationProvider).ToListAsync();
            return candidates;
        }

        public async Task<CandidateDTO> GetCandidateAsync(int candidateId)
        {
            var candidate = await context.Candidates.FindAsync(candidateId);
            var candidateDTO = mapper.Map<CandidateDTO>(candidate);
            return candidateDTO;
        }

        public async Task<CandidateDTO> AddCandidateAsync(Candidate candidate)
        {
            this.context.Candidates.Add(candidate);
            await this.context.SaveChangesAsync();
            return  this.mapper.Map<CandidateDTO>(candidate);
          
        }

        public async Task<CandidateDTO> UpdateCandidateAsync(Candidate candidate)
        {
            this.context.Candidates.Update(candidate);
            await this.context.SaveChangesAsync();
            return this.mapper.Map<CandidateDTO>(candidate);
        }

        public async Task DeleteCandidateAsync(int candidateId)
        {
            var candiateToRemove = await context.Candidates.FindAsync(candidateId);
            if (candiateToRemove == null) throw new Exception("There's no candidate with this id");
            this.context.Candidates.Remove(candiateToRemove);
            await this.context.SaveChangesAsync();
        }
    }
}
