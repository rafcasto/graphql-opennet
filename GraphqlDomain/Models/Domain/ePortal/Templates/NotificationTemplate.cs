using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlDomain.Models.Domain.ePortal.Templates
{
    public class NotificationTemplate : BaseTemplate
    {
        
        public int[] messagetemplateid { get; set; }
        public string[] receiver { get; set; }
        public string[] createdate { get; set; }
        public string[] createuser { get; set; }
        public string[] senddate { get; set; }

        public NotificationModel Build()
        {
            var faker = new Faker<NotificationModel>()
              .RuleFor(n => n.messagetemplateid, f => isNotEmpty(this.messagetemplateid) ? f.PickRandom(this.messagetemplateid) : 1)
              .RuleFor(n => n.receiver, f => isNotEmpty(receiver) ? f.PickRandom(this.receiver) : f.Internet.Email())
              .RuleFor(n => n.createdate, f => isNotEmpty(createdate) ? f.PickRandom(this.createdate)  : "2023-09-18 14:30:00.000000")           
              .RuleFor(n => n.createuser, f => isNotEmpty(createuser) ? f.PickRandom(this.createuser) + "_GAUTOMATION" : "CREATEDUSER_GAUTOMATION")
              .RuleFor(n => n.senddate, f => isNotEmpty(senddate) ? f.PickRandom(this.senddate) : "2023-09-18 14:30:00.000000");
            return faker.Generate();
        }

    }
}
