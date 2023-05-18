using GraphQL.Types;
using GraphqlAPI.Operations;

namespace GraphqlAPI.Schemas
{
    public class OpenNetSchema : Schema
    {
        public OpenNetSchema(IServiceProvider serviceProvider) : base(serviceProvider) 
        {
            Query = serviceProvider.GetRequiredService<QueryOpenNet>();
            Mutation = serviceProvider.GetRequiredService<MutationOpenNet>();
        }
    }
}
