using Travel.Library.Application.Features.Author.Queries.GetAllAuthors;
using Travel.Library.Application.Features.Publisher.Queries.GetAllPublishers;

namespace Travel.Library.Application.Features.Book.Queries.GetAllBooks
{
    public class BookDto
    {
      public string? Title { get; set; }
      public string? Synopsis { get; set; }
      public List<AuthorDto>? Authors { get; set; }
      public PublisherDto? Publishers { get; set; }
    }
}