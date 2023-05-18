using GraphqlDomain.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlDomain.Contract
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User CreateUser(User request);
    }
}
