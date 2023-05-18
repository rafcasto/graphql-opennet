using GraphQL;
using GraphQL.Types;
using GraphqlDomain.Contract;
using GraphqlDomain.Models.API.IRD;
using GraphqlDomain.Models.API.Users;
using GraphqlDomain.Models.Domain;
using GraphqlDomain.Models.Domain.IRD;

namespace GraphqlAPI.Operations
{
    public class MutationOpenNet : ObjectGraphType<object>
    {
        public MutationOpenNet(IIRDRepository iRDRepository
            , IUserRepository userRepository) 
        {
            Name = "MutationOpenNet";
            Field<ListGraphType<IRDResponseType>>("generateTaxNumbers")
                .Argument<IRDRequestInputType>("iRDRequestInputType")
                .Resolve(context => iRDRepository.GenerateTaxNumbers(context.GetArgument<IRDRequest>("iRDRequestInputType")));
            Field<UserType>("createUser")
                .Argument<UserInputType>("request")
                .Resolve(context => userRepository.CreateUser(context.GetArgument<User>("request")));
        }
    }
}
