using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlDomain.Models.Domain.IRD
{
    public class IRDResponse
    {
        public string IRDNumber { get; set; }   
        public bool HasLinkedCustomer { get; set; }
        public string UserName { get; set; }    
    }
}
