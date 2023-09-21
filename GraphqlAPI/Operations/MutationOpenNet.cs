using GraphQL;
using GraphQL.Types;
using GraphqlDomain.Contract;
using GraphqlDomain.Contract.ePortal;
using GraphqlDomain.Models.API.ePortal;
using GraphqlDomain.Models.API.IRD;
using GraphqlDomain.Models.API.Users;
using GraphqlDomain.Models.Domain;
using GraphqlDomain.Models.Domain.ePortal.Requests;
using GraphqlDomain.Models.Domain.IRD;

namespace GraphqlAPI.Operations
{
    public class MutationOpenNet : ObjectGraphType<object>
    {
        public MutationOpenNet(IIRDRepository iRDRepository
            , IUserRepository userRepository
            , INotificationsRepository notificationsRepository) 
        {
            Name = "MutationOpenNet";
            Field<ListGraphType<IRDResponseType>>("generateTaxNumbers")
                .Argument<IRDRequestInputType>("iRDRequestInputType")
                .Resolve(context => iRDRepository.GenerateTaxNumbers(context.GetArgument<IRDRequest>("iRDRequestInputType")));
            Field<UserType>("createUser")
                .Argument<UserInputType>("request")
                .Resolve(context => userRepository.CreateUser(context.GetArgument<User>("request")));
            Field<BaseResponseType>("CreateNotificationType")
                .Argument<NotificationTypeTemplateRequestInputType>("request")
                .Resolve(context => notificationsRepository.CreateNotificationType(context.GetArgument<NotificationTypeTemplateRequest>("request")));
            Field<BaseResponseType>("DeleteAllNotificationsType")
               .Argument<DeleteRequestInputType>("request")
               .Resolve(context => notificationsRepository.DeleteAllNotificationsType(context.GetArgument<BaseTemplateRequest<object>>("request")));
            Field<BaseResponseType>("CreateMessageTemplate")
               .Argument<MessageTemplateTemplateRequestInputType>("request")
               .Resolve(context => notificationsRepository.CreateMessageTemplateTemplate(context.GetArgument<MessageTemplateTemplateRequest>("request")));
            Field<BaseResponseType>("DeleteAllMessageTemplate")
               .Argument<DeleteRequestInputType>("request")
               .Resolve(context => notificationsRepository.DeleteAllMessageTemplate(context.GetArgument<BaseTemplateRequest<object>>("request")));
            Field<BaseResponseType>("CreateNotifications")
               .Argument<NotificationTemplateRequestInputType>("request")
               .Resolve(context => notificationsRepository.CreateNotification(context.GetArgument<NotificationTemplateRequest>("request")));
            Field<BaseResponseType>("DeleteAllNotifications")
               .Argument<DeleteRequestInputType>("request")
               .Resolve(context => notificationsRepository.DeleteAllNotification(context.GetArgument<BaseTemplateRequest<object>>("request")));
        }
    }
}
