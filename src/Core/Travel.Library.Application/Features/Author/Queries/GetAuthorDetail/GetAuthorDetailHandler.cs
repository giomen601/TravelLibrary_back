using AutoMapper;
using MediatR;
using Travel.Library.Application.Contracts.Persistence;

namespace Travel.Library.Application.Features.Author.Queries.GetAuthorDetail;
public class GetAuthorDetailHandler : IRequestHandler<GetAuthorDetailQuery, AuthorDetailDto>
{
  private readonly IMapper mapper;
  private readonly IAuthorRepository authorRepository;

  public GetAuthorDetailHandler
  (
    IMapper mapper,
    IAuthorRepository authorRepository
  )
  {
    this.mapper = mapper;
    this.authorRepository = authorRepository;
  }
  public async Task<AuthorDetailDto> Handle
  (
    GetAuthorDetailQuery request,
    CancellationToken cancellationToken
  )
  {
    var author = await authorRepository.GetByIdAsync(request.Id);

    var data = mapper.Map<AuthorDetailDto>(author);

    return data;
  }
}