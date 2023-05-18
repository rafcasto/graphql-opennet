using System.Security.Claims;

namespace GraphqlAPI
{
    public class GraphQLUserContext : Dictionary<string, object>
    {
        public ClaimsPrincipal User { get; set; }
    }
}