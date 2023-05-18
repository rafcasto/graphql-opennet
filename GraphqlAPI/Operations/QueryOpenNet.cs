using GraphQL.Types;
using GraphqlDomain.Contract;
using GraphqlDomain.Models.API.Users;

namespace GraphqlAPI.Operations
{
    public class QueryOpenNet : ObjectGraphType
    {
        public QueryOpenNet(IUserRepository userRepository) 
        {
            Name = "Query";
            Field<ListGraphType<UserType>>("users").Resolve( context => userRepository.GetUsers());
        }
    }
}
