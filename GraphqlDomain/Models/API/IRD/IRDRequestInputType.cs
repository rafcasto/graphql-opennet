using GraphQL.Types;
using GraphqlDomain.Models.Domain.IRD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlDomain.Models.API.IRD
{
    public class IRDRequestInputType : InputObjectGraphType<IRDRequest>
    {
        public IRDRequestInputType()
        {
            Name = "IRDRequestInputType";
            Description = "Generate IRD Numbers"; 
            Field(ird => ird.Seed,nullable: false).Description("IRD Seed Example: 111111111");
            Field(ird => ird.Total, nullable: false).Description("Quantity of IRD Example: 10");
        }
    }
}
