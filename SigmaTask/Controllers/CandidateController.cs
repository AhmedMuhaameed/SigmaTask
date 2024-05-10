using Microsoft.AspNetCore.Mvc;
using SigmaTask.Services.Abstraction;
using SigmaTask.Services.DTO;

namespace SigmaTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IJobCandidateService jobCandidateService;

        public CandidateController(IJobCandidateService jobCandidateService)
        {
            this.jobCandidateService = jobCandidateService;
        }
        [HttpGet]
        public async Task<ActionResult<ResponseDTO<List<CandidateDTO>>>> GetCandidates()
        {
            var brands = await this.jobCandidateService.GetCandidatesAsync();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDTO<CandidateDTO>>> GetCandidate(int id)
        {
            var brand = await this.jobCandidateService.GetCandidateAsync(id);
            return Ok(brand);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDTO<CandidateDTO>>> AddCandidate(AddCandidateDTO passedBrand)
        {
            var response = await this.jobCandidateService.AddCandidateAsync(passedBrand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseDTO<CandidateDTO>>> UpdateCandidate(CandidateDTO passedBrand)
        {
            var brand = await this.jobCandidateService.UpdateCandidateAsync(passedBrand);
            return Ok(brand);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmptyResponse>> DeleteCandidate(int id)
        {
            var brand = await this.jobCandidateService.DeleteCandidateAsync(id);
            return Ok(brand);
        }
    }
}
