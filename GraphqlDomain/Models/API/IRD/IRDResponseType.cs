using GraphQL.Types;
using GraphqlDomain.Models.Domain.IRD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlDomain.Models.API.IRD
{
    public class IRDResponseType : ObjectGraphType<IRDResponse>
    {
        public IRDResponseType()
        {
            Name = "IRDResponseType";
            Description = "IRD Response";
            Field(ird => ird.UserName, nullable: true).Description("User Name linked to IRD");
            Field(ird => ird.IRDNumber, nullable: true).Description("ird Numer");
            Field(ird => ird.HasLinkedCustomer, nullable: true).Description("is IRD number linked to User");




        }
    }
}
