using AwesomeUrl.Data;
using AwesomeUrl.GraphQL.InputTypes;
using AwesomeUrl.Models;
using HotChocolate.AspNetCore.Authorization;

namespace AwesomeUrl.GraphQL
{
  public class Mutation
  {

    [Authorize]
    [UseDbContext(typeof(ShortURLDbContext))]
    public async Task<ShortURL> AddShortURLAsync([ScopedService] ShortURLDbContext context, AddShortURLInput shortURLInput)
    {
      var ShortURL = new ShortURL
      {
        Url = shortURLInput.Url
      };

      // TODO: actually shorten the URL.

      context.ShortURLs.Add(ShortURL);
      await context.SaveChangesAsync();

      return ShortURL;
    }
  }
}