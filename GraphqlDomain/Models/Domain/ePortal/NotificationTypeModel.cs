using Bogus;
using GraphqlDomain.Models.Domain.ePortal.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlDomain.Models.Domain.ePortal
{
    public class NotificationTypeModel
    {
        public int notificationtypeid { get; set; }
        public string notificationtype { get; set; }
        public bool issms {  get; set; }

     
    }
}
