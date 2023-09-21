using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlDomain.Models.Domain.ePortal.Response
{
    public class BaseResponse
    {
        public string message { get; set; }
        public string error { get; set; }
        public string stacktrace { get; set; }
        public List<DBResponse> dBResponses { get; set; }
    }

    public class DBResponse
    {
        public int Id;
        public string error { get; set; }
        public string stacktrace { get; set; }

    }
}
