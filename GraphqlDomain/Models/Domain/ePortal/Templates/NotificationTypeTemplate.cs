using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
namespace GraphqlDomain.Models.Domain.ePortal.Templates
{
    public class NotificationTypeTemplate : BaseTemplate
    {

        public string[] notificationtype { get; set; } = new string[0];
        public bool[] issms { get; set; } = new bool[0];

        public  NotificationTypeModel Build()
        {
            var faker = new Faker<NotificationTypeModel>()
                .RuleFor(n => n.notificationtype, f => isNotEmpty(this.notificationtype) ?  f.PickRandom(this.notificationtype) + "_GAUTOMATION" : "DEFAULT_GAUTOMATION")
                .RuleFor(n => n.issms, f => isNotEmpty(issms) ? f.PickRandom(this.issms) : false);
            return faker.Generate();
        }

      

    }
}
