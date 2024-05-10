using AutoMapper;
using Moq;
using SigmaTask.Entities.Models;
using SigmaTask.Repository.Abstraction;
using SigmaTask.Services.DTO;
using SigmaTask.Services.Implmentation;
using Xunit;

namespace SigmaTask.UnitTests
{
    public class JobCandidateServiceTests
    {
        [Fact]
        public async Task AddCandidateAsync_ValidCandidate_ReturnsSuccessResponse()
        {
            // Arrange
            var mockRepository = new Mock<IJobCandidateRepository>();
            var mockMapper = new Mock<IMapper>();
            var service = new JobCandidateService(mockRepository.Object);

            var addCandidateDTO = new AddCandidateDTO
            {
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "1234567890",
                Email = "john.doe@example.com",
                CallTime = "Morning",
                LinkedInUrl = "https://www.linkedin.com/in/johndoe",
                GitHubUrl = "https://github.com/johndoe",
                Comment = "Excellent candidate"

            };

            var candidateEntity = new Candidate
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "1234567890",
                Email = "john.doe@example.com",
                CallTime = "Morning",
                LinkedInUrl = "https://www.linkedin.com/in/johndoe",
                GitHubUrl = "https://github.com/johndoe",
                Comment = "Excellent candidate"
            };
            var candidateDTO = new CandidateDTO() { };
            mockMapper.Setup(m => m.Map<Candidate>(addCandidateDTO)).Returns(candidateEntity);
            mockRepository.Setup(r => r.AddCandidateAsync(It.IsAny<Candidate>())).ReturnsAsync(candidateDTO);

            // Act
            var response = await service.AddCandidateAsync(addCandidateDTO);

            // Assert
            Assert.True(response.IsSuccess);
            Assert.Equal("Candidate Added Successfully", response.Message);
        }

        [Fact]
        public async Task AddCandidateAsync_RepositoryThrowsException_ReturnsFailureResponse()
        {
            // Arrange
            var mockRepository = new Mock<IJobCandidateRepository>();
            var mockMapper = new Mock<IMapper>();
            var service = new JobCandidateService(mockRepository.Object);

            var addCandidateDTO = new AddCandidateDTO
            {
                FirstName = "",
                LastName = "",
                PhoneNumber = "1234567890",
                Email = "john.doe@example.com",
                CallTime = "Morning",
                LinkedInUrl = "https://www.linkedin.com/in/johndoe",
                GitHubUrl = "https://github.com/johndoe",
                Comment = "Excellent candidate"
            };

            var candidateEntity = new Candidate
            {
                Id = 1,
                FirstName = "",
                LastName = "",
                PhoneNumber = "1234567890",
                Email = "john.doe@example.com",
                CallTime = "Morning",
                LinkedInUrl = "https://www.linkedin.com/in/johndoe",
                GitHubUrl = "https://github.com/johndoe",
                Comment = "Excellent candidate"
            };

            mockMapper.Setup(m => m.Map<Candidate>(addCandidateDTO)).Returns(candidateEntity);
            mockRepository.Setup(r => r.AddCandidateAsync(candidateEntity)).ThrowsAsync(new Exception("Simulated repository exception"));

            // Act
            var response = await service.AddCandidateAsync(addCandidateDTO);

            // Assert
            Assert.False(response.IsSuccess);
            Assert.Equal("Cannot Add Candidate", response.Message);
        }

    }
}
