using Travel.Library.Domain.Common;

namespace Travel.Library.Domain.Entities;
public class Publishers : BaseEntity
{
  public string? Name { get; set; }
  public string? HouseLocation { get; set; }
}