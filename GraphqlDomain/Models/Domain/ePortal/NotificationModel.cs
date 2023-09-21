using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlDomain.Models.Domain.ePortal
{
    public class NotificationModel
    {
        public int notificationid { get; set; }
        public int messagetemplateid { get; set; }
        public string receiver {  get; set; }
        public string createdate { get; set; }
        public string createuser { get; set; }
        public string senddate { get; set; }
    }
}
