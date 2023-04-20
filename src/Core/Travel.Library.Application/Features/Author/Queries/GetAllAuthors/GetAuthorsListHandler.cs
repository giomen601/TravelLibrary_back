using AutoMapper;
using MediatR;
using Travel.Library.Application.Contracts.Persistence;

namespace Travel.Library.Application.Features.Author.Queries.GetAllAuthors;
public class GetAuthorsListHandler : IRequestHandler<GetAuthorsListQuery, List<AuthorDto>>
{
  private readonly IMapper mapper;
  private readonly IAuthorRepository authorRepository;

  public GetAuthorsListHandler
  (
    IMapper mapper,
    IAuthorRepository authorRepository
  )
  {
    this.mapper = mapper;
    this.authorRepository = authorRepository;
  }
  

  public async Task<List<AuthorDto>> Handle
  (
    GetAuthorsListQuery request,
    CancellationToken cancellationToken
  )
  {
    //Get from database
    //var authors = await authorRepository.GetAsync();
    var authors = await authorRepository.GetAuthorWithDetails();

    //Converto to DTO objects
    var data = mapper.Map<List<AuthorDto>>(authors);

    //return list of DTOs objects
    return data;
  }
}