using Travel.Library.Domain.Common;

namespace Travel.Library.Domain.Entities;
public class Book : BaseEntity
{
  public string? Title { get; set; }
  public string? Synopsis { get; set; }
  public int PublishersId { get; set; }
  public List<AuthorBook>? AuthorsBooks { get; set; }
  public List<Author>? Authors { get; set; }
  public Publishers? Publishers { get; set; }
}