using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlDomain.Models.Domain.ePortal.Requests
{
    public class BaseTemplateRequest<T>
    {
        public T template { get; set; }
        public string Schema { get; set; }
        public int Quantity {  get; set; }

    }
}
