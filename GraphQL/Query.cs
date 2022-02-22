using AwesomeUrl.Data;
using AwesomeUrl.Models;
using HotChocolate.AspNetCore.Authorization;

namespace AwesomeUrl.GraphQL
{
  public class Query
  {
    [Authorize]
    [UseDbContext(typeof(ShortURLDbContext))]
    public IQueryable<ShortURL> GetShortURL([ScopedService] ShortURLDbContext context)
    {
      return context.ShortURLs;
    }
  }
}
