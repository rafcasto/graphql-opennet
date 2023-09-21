using GraphqlDomain.Contract.ePortal;
using GraphqlDomain.Models;
using GraphqlDomain.Models.Domain.ePortal;
using GraphqlDomain.Models.Domain.ePortal.Requests;
using GraphqlDomain.Models.Domain.ePortal.Response;
using GraphqlDomain.Models.Domain.ePortal.Templates;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlBusiness.Repository.ePortal
{
    public class NotificationsRepository : BaseDBRepository, INotificationsRepository
    {
        private string sqlRetrieveLastNotificationTypeId = "SELECT notificationtypeid  FROM {0}.tabnotificationtype ORDER BY notificationtypeid DESC LIMIT 1";
        private string sqlRetrieveLastNotificationId = "SELECT notificationid  FROM {0}.tabnotification ORDER BY notificationid DESC LIMIT 1";
        private string sqlDeleteNotificationRecords = "DELETE FROM {0}.tabnotification WHERE createuser like '%_GAUTOMATION%'";
        private string sqlRetrieveLastMessageTemplateId = "SELECT messagetemplateid  FROM {0}.tabmessagetemplate ORDER BY messagetemplateid DESC LIMIT 1";
        private string sqlDeleteNotificationTypeRecords = "DELETE FROM {0}.tabnotificationtype WHERE notificationtype like '%_GAUTOMATION%'";
        private string sqlDeleteMessageTemplateRecords = "DELETE FROM {0}.tabmessagetemplate WHERE subject like '%_GAUTOMATION%'";


        public NotificationsRepository(IConfiguration configuration) : base(configuration)
        {           

        }

        public BaseResponse CreateMessageTemplateTemplate(BaseTemplateRequest<MessageTemplateTemplate> request)
        {          
            return InsertTemplate(request, BuildMessageTemplateTemplateInsertString, sqlRetrieveLastMessageTemplateId);
        }

        public BaseResponse CreateNotificationType(BaseTemplateRequest<NotificationTypeTemplate> request)
        {
            return InsertTemplate(request, BuildNotificationTypeSqlInsertString, sqlRetrieveLastNotificationTypeId);
        }

        public BaseResponse CreateNotification(BaseTemplateRequest<NotificationTemplate> request)
        {

            return InsertTemplate(request, BuildNotificationTemplateInsertString, sqlRetrieveLastNotificationId); ;
        }

        public BaseResponse DeleteAllMessageTemplate(BaseTemplateRequest<object> request)
        {
            
            return DeleteRecord(request, sqlDeleteMessageTemplateRecords);
        }

        public BaseResponse DeleteAllNotificationsType(BaseTemplateRequest<object> request)
        {
            
            return DeleteRecord(request, sqlDeleteNotificationTypeRecords);
        }

       

        public BaseResponse DeleteAllNotification(BaseTemplateRequest<object> request)
        {
            return DeleteRecord(request, sqlDeleteNotificationRecords);
        }


        private string BuildNotificationTemplateInsertString(NotificationTemplate temp)
        {
            var table = temp.Build();
            return "INSERT INTO {0}.tabnotification (messagetemplateid, receiver, createdate, createuser, senddate) VALUES (" +
                $"{table.messagetemplateid}" +
                $", '{table.receiver}'" +
                $", '{table.createdate}'" +
                $", '{table.createuser}'" +
                $", '{table.senddate}');";
        }
        public string BuildMessageTemplateTemplateInsertString(MessageTemplateTemplate temp)
        {
            var table = temp.Build();
           
            return "INSERT INTO {0}.tabmessagetemplate ( applicationid, notificationtypeid, languagecode, sender, subject, body) " +
                $"VALUES " +
                $"(" +
                $"{table.applicationid}" +
                $", {table.notificationtypeid}" +
                $", '{table.languagecode}'" +
                $", '{table.sender}'" +
                $", '{table.subject}'" +
                $", '{table.body}');";
        }

        private string BuildNotificationTypeSqlInsertString(NotificationTypeTemplate temp) 
        {
            var notificationModel = temp.Build();
            return  "INSERT INTO {0}.tabnotificationtype (notificationtype, issms) " +
                $"VALUES ( " +
                $"'{notificationModel.notificationtype}'" +
                $",{notificationModel.issms});";
        }

        
    }
}
