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
    public class MessageTemplateTemplateRequestInputType : InputObjectGraphType<MessageTemplateTemplateRequest>
    {
        public MessageTemplateTemplateRequestInputType()
        {
            Name = "MessageTemplateTemplateRequestInputType";
            Description = "Message template request";
            Field(msType => msType.Quantity, nullable: false).Description("Quantity of data to be generated, minimun 1");
            Field(msType => msType.Schema, nullable: false).Description("database schema you want to query example ePortal");
            Field(msType => msType.template, nullable: true, type: typeof(MessageTemplateTemplateInputType)).Description("This template define default values for data generation");

        }
    }

    public class MessageTemplateTemplateInputType : InputObjectGraphType<MessageTemplateTemplate> 
    {
        public MessageTemplateTemplateInputType() 
        {
            Name = "MessageTemplateTemplateInputType";
            Description = "Message template request";
            Field(msType => msType.applicationid, nullable: true).Description("application id default value 1");
            Field(msType => msType.notificationtypeid, nullable: true).Description("notificationtype id default value 1");
            Field(msType => msType.sender, nullable: true).Description("sender default value test@test.com");
            Field(msType => msType.subject, nullable: true).Description("subject default value GAUTOMATION_SUBJECT");
            Field(msType => msType.body, nullable: true).Description("body default value 'Test Body'");
            Field(msType => msType.languagecode, nullable: true).Description("Lenguage EN | FR ");
        }

    }
}
