using GraphQL.Types;
using GraphqlDomain.Models.Domain.ePortal.Response;
using GraphqlDomain.Models.Domain.IRD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlDomain.Models.API.ePortal
{
    public class BaseResponseType : ObjectGraphType<BaseResponse>
    {
        public BaseResponseType () 
        {
            Name = "BaseResponseType";
            Field(br => br.message, nullable: true).Description("Success message");
            Field(br => br.error, nullable: true).Description("Error message");
            Field(br => br.stacktrace, nullable: true).Description("Stack trace error message");
            Field(br => br.dBResponses, nullable: true,type: typeof(ListGraphType<DBResponseType>)).Description("DB Response");

        }
    }

    public class DBResponseType : ObjectGraphType<DBResponse> 
    {
        public DBResponseType() 
        {
            Name = "DBResponseType";
            Field(br => br.Id, nullable: true).Description("record id");
            Field(br => br.error, nullable: true).Description("error description");
            Field(br => br.stacktrace, nullable: true).Description("Stack trace error message");

        }
    }
}
