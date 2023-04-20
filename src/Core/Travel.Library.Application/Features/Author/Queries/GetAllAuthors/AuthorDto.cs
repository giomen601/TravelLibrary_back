using Travel.Library.Application.Features.Book.Queries.GetAllBooks;

namespace Travel.Library.Application.Features.Author.Queries.GetAllAuthors;
public class AuthorDto
{
  public string? Name { get; set; }
  public string? Lastname { get; set; }
  public List<BookDto>? Books { get; set; }
}