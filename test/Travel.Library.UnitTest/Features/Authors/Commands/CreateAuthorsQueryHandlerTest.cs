using AutoMapper;
using Moq;
using Travel.Library.Application.Contracts.Persistence;
using Travel.Library.Application.Features.Author.Commands.CreateAuthor;
using Travel.Library.Application.MappingProfile;
using Travel.Library.UnitTest.Mocks;

namespace Travel.Library.UnitTest.Features.Authors.Commands;
public class CreateAuthorsQueryHandlerTest
{
  private readonly Mock<IAuthorRepository> _mockRepo;
  private IMapper _mapper;

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
  }

  [Fact]
  public async Task CreateAuthorsTest()
  {
    var handler = new CreateAuthorCommandHandler(_mapper, _mockRepo.Object);
    var result = await handler.Handle(new CreateAuthorCommand(), CancellationToken.None);

    //result.Equals()
  }
}