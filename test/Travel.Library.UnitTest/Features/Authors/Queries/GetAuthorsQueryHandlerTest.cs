using AutoMapper;
using Moq;
using Shouldly;
using Travel.Library.Application.Contracts.Persistence;
using Travel.Library.Application.Features.Author.Queries.GetAllAuthors;
using Travel.Library.Application.MappingProfile;
using Travel.Library.UnitTest.Mocks;

namespace Travel.Library.UnitTest.Features.Authors.Queries;
public class GetAuthorsQueryHandlerTest
{
  private readonly Mock<IAuthorRepository> _mockRepo;
  private IMapper _mapper;
  public GetAuthorsQueryHandlerTest()
  {
    _mockRepo = MockAuthorRepository.GetMockAuthorRepository();

    var mapperConfig = new MapperConfiguration
    (
      c => 
      {
        c.AddProfile<AuthorsProfile>();
      }
    );

    _mapper = mapperConfig.CreateMapper();
  }

  [Fact]
  public async Task GetAuthorsTest()
  {
    var handler = new GetAuthorsListHandler(_mapper, _mockRepo.Object);
    var result = await handler.Handle(new GetAuthorsListQuery(), CancellationToken.None);

    result.ShouldBeOfType<List<AuthorDto>>();
    result.Count.ShouldBe(3);
  }
}