using AutoMapper;
using Moq;
using Shouldly;
using Travel.Library.Application.Contracts.Persistence;
using Travel.Library.Application.Features.Author.Commands.CreateAuthor;
using Travel.Library.Application.Features.Author.Queries.GetAllAuthors;
using Travel.Library.Application.MappingProfile;
using Travel.Library.UnitTest.Mocks;

namespace Travel.Library.UnitTest.Features.Authors.Commands;
public class CreateAuthorsQueryHandlerTest
{
  private readonly Mock<IAuthorRepository> _mockRepo;
  private IMapper _mapper;
  private readonly AuthorDto _authorDto;

  public CreateAuthorsQueryHandlerTest()
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

    _authorDto = new AuthorDto
    {
      Name = "New",
      Lastname = "unittest author"
    };
  }

  [Fact]
  public async Task CreateAuthorsTest()
  {
    var handler = new CreateAuthorCommandHandler(_mapper, _mockRepo.Object);
    
    var result = await handler.Handle
    (
      new CreateAuthorCommand()
      {
        Name = _authorDto.Name,
        Lastname = _authorDto.Lastname
      },
      CancellationToken.None
    );

    var author = await _mockRepo.Object.GetAsync();

    result.ShouldBeOfType<int>();
    author.Count.ShouldBe(4);
  }
}