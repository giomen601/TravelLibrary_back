using Travel.Library.Domain.Common;

namespace Travel.Library.Domain.Entities;
public class Author : BaseEntity
{
  public string? Name { get; set; }
  public string? Lastname { get; set; }
  public Book? Books { get; set; }
  public List<AuthorBook>? AuthorsBooks { get; set; }
}