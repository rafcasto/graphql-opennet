using GraphqlDomain.Models.Domain.ePortal;
using GraphqlDomain.Models.Domain.ePortal.Requests;
using GraphqlDomain.Models.Domain.ePortal.Response;
using GraphqlDomain.Models.Domain.ePortal.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlDomain.Contract.ePortal
{
    public interface INotificationsRepository
    {
        public BaseResponse CreateNotificationType(BaseTemplateRequest<NotificationTypeTemplate> template);
        public BaseResponse CreateMessageTemplateTemplate(BaseTemplateRequest<MessageTemplateTemplate> request);
        public BaseResponse DeleteAllNotificationsType(BaseTemplateRequest<object> request);
        public BaseResponse DeleteAllMessageTemplate(BaseTemplateRequest<object> request);
        public BaseResponse CreateNotification(BaseTemplateRequest<NotificationTemplate> request);
        public BaseResponse DeleteAllNotification(BaseTemplateRequest<object> request);
    }
}
