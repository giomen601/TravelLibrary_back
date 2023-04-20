namespace Travel.Library.Domain.Entities;
public class AuthorBook
{
  public int AuthorsId { get; set; }
  public int BookId { get; set; }
  public Author? Authors { get; set; }
  public Book? Books { get; set; }
}