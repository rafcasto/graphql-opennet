using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlDomain.Models.Domain.ePortal
{
    public class MessageTemplateModel
    {
        public int messagetemplateid { get;set; }
        public int applicationid { get;set;}
        public int notificationtypeid { get;set;}
        public string languagecode { get;set;}
        public string sender { get;set;}    
        public string subject { get;set;}
        public string body { get;set;}
    }
}
