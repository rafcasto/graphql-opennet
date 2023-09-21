using GraphQL.Types;
using GraphqlDomain.Models.Domain.ePortal.Requests;
using GraphqlDomain.Models.Domain.ePortal.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlDomain.Models.API.ePortal
{
    public class NotificationTemplateRequestInputType : InputObjectGraphType<NotificationTemplateRequest>
    {
        public NotificationTemplateRequestInputType() 
        {
            Name = "NotificationTemplateRequestInputType";
            Description = "Notification request";
            Field(msType => msType.Quantity, nullable: false).Description("Quantity of data to be generated, minimun 1");
            Field(msType => msType.Schema, nullable: false).Description("database schema you want to query example ePortal");
            Field(msType => msType.template, nullable: true, type: typeof(NotificationTemplateInputType)).Description("This template define default values for data generation");

        }
    }


    public class NotificationTemplateInputType : InputObjectGraphType<NotificationTemplate>
    {
        public NotificationTemplateInputType()
        {
            Name = "NotificationTemplateInputType";
            Description = "Notification Template ";
            Field(msType => msType.messagetemplateid, nullable: true).Description("messagetemplateid id default value 1");
            Field(msType => msType.receiver, nullable: true).Description("receiver default value test@test.com");
            Field(msType => msType.createuser, nullable: true).Description("createduser default value CREATEDUSER_GAUTOMATION");
            Field(msType => msType.createdate, nullable: true).Description("createddate default value 2023-09-18 14:30:00.000000, FORMAT YYYY-MM-DD hh:mm:ss.ssss");
            Field(msType => msType.senddate, nullable: true).Description("senddate default value 2023-09-18 14:30:00.000000, FORMAT YYYY-MM-DD hh:mm:ss.ssss");
        }
    }

}
