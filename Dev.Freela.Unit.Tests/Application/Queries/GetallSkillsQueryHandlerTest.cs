using AutoFixture;
using Dev.Freela.Application.Queries.Skills;
using Dev.Freela.Core.DTOs;
using Dev.Freela.Core.Repositories;
using Moq;

namespace Dev.Freela.Unit.Tests.Application.Queries
{
    public class GetallSkillsQueryHandlerTest
    {
        private readonly Mock<ISkillRepository> _skillRepositoryMock;

        public GetallSkillsQueryHandlerTest()
        {
            _skillRepositoryMock = new Mock<ISkillRepository>();
        }

        [Fact]
        public async Task ThreeUserSkillExists_Executed_ReturnThreeUserSkillDto()
        {
            // Arrange
            var fixture = new Fixture();

            var userSkillA = fixture.Create<SkillDto>();
            var userSkillB = fixture.Create<SkillDto>();
            var userSkillC = fixture.Create<SkillDto>();

            var userSkills = new List<SkillDto>();
            userSkills.Add(userSkillA);
            userSkills.Add(userSkillB);
            userSkills.Add(userSkillC);

            _skillRepositoryMock.Setup(x => x.GetAllAsync())
                .Returns(Task.FromResult(userSkills));

            var getAllSkillQuery = fixture.Create<GetAllSkillQuery>();
            var getAllSkillQueryHandler = new GetAllSkillsQueryHandler(_skillRepositoryMock.Object);

            // Action
            var result = await getAllSkillQueryHandler.Handle(getAllSkillQuery, new CancellationToken());

            // Assert
            _skillRepositoryMock.Verify(x => x.GetAllAsync(), Times.Once);
            Assert.NotEmpty(result);
        }
    }
}
