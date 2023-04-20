using MediatR;

namespace Travel.Library.Application.Features.Author.Queries.GetAllAuthors;
public record GetAuthorsListQuery : IRequest<List<AuthorDto>>;