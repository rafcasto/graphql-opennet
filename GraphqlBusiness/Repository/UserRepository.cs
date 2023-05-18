using GraphqlDomain.Contract;
using GraphqlDomain.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlBusiness.Repository
{
    public class UserRepository : IUserRepository
    {
        private List<User> users;

        public User CreateUser(User request)
        {
            if (users == null)
            {
                users =  new List<User>();
            }

            users.Add(request);
            return request;
        }

        public List<User> GetUsers()
        {
            if (users == null) { 
                return new List<User>();
            }

            return users;
        }
    }
}
