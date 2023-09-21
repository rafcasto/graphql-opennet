using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlDomain.Models.Domain.ePortal.Templates
{
    public class BaseTemplate
    {
        
        public bool isNotEmpty(string[] attribute)
        {
            return attribute != null && attribute.Any();
        }

        public bool isNotEmpty(bool[] attribute)
        {
            return attribute != null && attribute.Any();
        }

        public bool isNotEmpty(int[] attribute)
        {
            return attribute != null && attribute.Any();
        }
    }
}
