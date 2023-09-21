using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlDomain.Models.Domain.ePortal.Templates
{
    public class MessageTemplateTemplate : BaseTemplate
    {
        public int[] applicationid { get; set; }
        public int[] notificationtypeid { get; set; }
        public string[] languagecode { get; set; }
        public string[] sender { get; set; }
        public string[] subject { get; set; }
        public string[] body { get; set; }

        public MessageTemplateModel Build() 
        {
            var faker = new Faker<MessageTemplateModel>()
              .RuleFor(n => n.applicationid, f => isNotEmpty(this.applicationid) ? f.PickRandom(this.applicationid) : 1)
              .RuleFor(n => n.notificationtypeid, f => isNotEmpty(notificationtypeid) ? f.PickRandom(this.notificationtypeid) : 1)
              .RuleFor(n => n.subject, f => isNotEmpty(subject) ? f.PickRandom(this.subject) + "_GAUTOMATION" : "SUBJECT_GAUTOMATION")
              .RuleFor(n => n.sender, f => isNotEmpty(sender) ? f.PickRandom(this.sender) : f.Internet.Email())
              .RuleFor(n => n.body, f => isNotEmpty(body) ? f.PickRandom(this.body) : "Test Body")
              .RuleFor(n => n.languagecode, f => isNotEmpty(languagecode) ? f.PickRandom(this.languagecode) : "EN");
            return faker.Generate();

        }
    }
}
