using GraphQL.Types;
using GraphqlDomain.Models.Domain.ePortal.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlDomain.Models.API.ePortal
{
    public class DeleteRequestInputType : InputObjectGraphType<BaseTemplateRequest<object>>
    {
        public DeleteRequestInputType() 
        {
            Name = "DeleteRequestInputType";
            Description = "Delete all records created by Graphql for a given table";
            Field(f => f.Schema,nullable: false).Description("schema where data is stored example ePortal");
        }
    }
}
