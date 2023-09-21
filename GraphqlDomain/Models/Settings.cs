using GraphQL;
using Microsoft.Extensions.Configuration;

namespace GraphqlDomain.Models
{
    public class Settings
    {
        private IConfiguration configuration; 
        public Settings(IConfiguration configuration) 
        {
            this.configuration = configuration;
        } 

        public string ConnectionStrings { get {
                return this.configuration.GetValue<string>("ConnectionStrings");
            } }
    }
}
