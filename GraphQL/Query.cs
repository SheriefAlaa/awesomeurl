using AwesomeUrl.Data;
using AwesomeUrl.Models;

namespace AwesomeUrl.GraphQL
{
  public class Query
  {
    [UseDbContext(typeof(ShortURLDbContext))]
    public IQueryable<ShortURL> GetShortURL([ScopedService] ShortURLDbContext context)
    {
      return context.ShortURLs;
    }
  }
}
