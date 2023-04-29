using Moq;
using Travel.Library.Application.Contracts.Persistence;
using Travel.Library.Domain.Entities;

namespace Travel.Library.UnitTest.Mocks;
public class MockAuthorRepository
{
    public static Mock<IAuthorRepository> GetMockAuthorRepository()
    {
      var authors = new List<Author>
      {
        new Author
        {
          Id = 1,
          Name = "Test one",
          Lastname = "First Mock",
        },
        new Author
        {
          Id = 2,
          Name = "Test tow",
          Lastname = "Second Mock"
        },
        new Author
        {
          Id = 3,
          Name = "Test third",
          Lastname = "Third Mock"
        }
      };

      var mockRepo = new Mock<IAuthorRepository>();

      mockRepo.Setup(x => x.GetAsync()).ReturnsAsync(authors);

      mockRepo.Setup(x => x.GetAuthorWithDetails()).ReturnsAsync(authors);

      mockRepo.Setup(x => x.CreateAsync(It.IsAny<Author>())).ReturnsAsync((Author author) =>
      {
        authors.Add(author);
        return author;
      });

      /*mockRepo.Setup(x => x.CreateAsync(It.IsAny<Author>()))
      .Returns((Author author) => {
        authors.Add(author);
        return Task.CompletedTask;
      });*/

      return mockRepo;
    }
}