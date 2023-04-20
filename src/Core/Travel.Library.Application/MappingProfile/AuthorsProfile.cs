using AutoMapper;
using Travel.Library.Application.Features.Author.Commands.CreateAuthor;
using Travel.Library.Application.Features.Author.Commands.UpdateAuthor;
using Travel.Library.Application.Features.Author.Queries.GetAllAuthors;
using Travel.Library.Application.Features.Author.Queries.GetAuthorDetail;
using Travel.Library.Application.Features.Book.Queries.GetAllBooks;
using Travel.Library.Domain.Entities;

namespace Travel.Library.Application.MappingProfile;
public class AuthorsProfile : Profile
{
  public AuthorsProfile()
  {
    CreateMap<AuthorDto, Author>();
    CreateMap<Author, AuthorDto>()
    .ForMember(authorDTO => authorDTO.Books,
    options => options.MapFrom(MapAuthorDTOBooks));
    
    CreateMap<AuthorDetailDto, Author>().ReverseMap();
    CreateMap<CreateAuthorCommand, Author>();
    CreateMap<UpdateAuthorCommand, Author>();
  }

  private List<BookDto> MapAuthorDTOBooks(Author author, AuthorDto authorDto)
  {
    var result = new List<BookDto>();

    if(author.AuthorsBooks == null) return result;

    foreach (var authorbook in author.AuthorsBooks)
    {
      result.Add(new BookDto()
      {
        Title = authorbook.Books?.Title,
        Synopsis = authorbook.Books?.Synopsis
      });
    }

    return result;
  }
}