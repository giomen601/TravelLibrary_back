using AutoMapper;
using Travel.Library.Application.Features.Author.Queries.GetAllAuthors;
using Travel.Library.Application.Features.Book.Commands.CreateBook;
using Travel.Library.Application.Features.Book.Commands.UpdateBook;
using Travel.Library.Application.Features.Book.Queries.GetAllBooks;
using Travel.Library.Application.Features.Book.Queries.GetBookDetail;
using Travel.Library.Domain.Entities;

namespace Travel.Library.Application.MappingProfile;
public class BooksProfile : Profile
{
 public BooksProfile()
 {
    CreateMap<BookDto, Book>();
    CreateMap<Book, BookDto>()
    .ForMember(bookDto => bookDto.Authors,
    options => options.MapFrom(MapBookDTOAuthors));

    CreateMap<BookDetailDto, Book>().ReverseMap();

    CreateMap<CreateBookCommand, Book>()
    .ForMember(book => book.AuthorsBooks,
    options => options.MapFrom(MapAuthorsBooks));

    CreateMap<UpdateBookCommand, Book>();
 } 
 
 private List<AuthorDto> MapBookDTOAuthors(Book books, BookDto bookDto)
 {
  var result = new List<AuthorDto>();

  if(books.AuthorsBooks == null) return result;

  foreach (var authorbook in books.AuthorsBooks)
  {
    result.Add(new AuthorDto()
    {
      Name = authorbook.Authors?.Name,
      Lastname = authorbook.Authors?.Lastname
    });
  }

  return result;
 }

  private List<AuthorBook>
  MapAuthorsBooks
  (
    CreateBookCommand createBookCommand,
    Book book
  )
  {
    var result = new List<AuthorBook>();

    if(createBookCommand.AuthorsId == null)
      return result;

    foreach(var authorId in createBookCommand.AuthorsId)
    {
      result.Add(new AuthorBook() { AuthorsId = authorId });
    }

    return result;
  } 
}