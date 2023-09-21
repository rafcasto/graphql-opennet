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
    public class NotificationTypeTemplateRequestInputType : InputObjectGraphType<NotificationTypeTemplateRequest>
    {
        public NotificationTypeTemplateRequestInputType() 
        { 
            Name = "NotificationTypeTemplateRequestInputType";
            Description = "Insert data on catalog Table - Notification Type";
            Field(msType => msType.Quantity, nullable: false).Description("Quantity of data to be generated, minimun 1");
            Field(msType => msType.Schema, nullable: false).Description("database schema you want to query example ePortal");
            Field(msType => msType.template, nullable:true,type: typeof(NotificationTypeTemplateInputType)).Description("This template define default values for data generation");
            

        }
    }

    public class NotificationTypeTemplateInputType : InputObjectGraphType<NotificationTypeTemplate>
    {
       public NotificationTypeTemplateInputType()
        {
            Name = "NotificationTypeTemplateInputType";
            Description = "Insert data on catalog Table Template - Notification Type";
            Field(msType => msType.notificationtype, nullable: true).Description("Notification Type: example .. ");
            Field(msType => msType.issms, nullable: true).Description("is SMS type values [true | false] ");


        }
    }
}
