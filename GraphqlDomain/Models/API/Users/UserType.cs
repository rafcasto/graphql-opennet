using GraphQL.Types;
using GraphqlDomain.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlDomain.Models.API.Users
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Name = "UserType";
            Description = "API To extract Users";
            Field(u => u.Name, nullable: true).Description("UserType: Name");
            Field(u => u.LastName, nullable: true).Description("UserType: LastName");
            Field(u => u.IRD, nullable: true).Description("UserType: IRD");
            Field(u => u.UserName, nullable: true).Description("UserType: UserName");
        }
    }
}
