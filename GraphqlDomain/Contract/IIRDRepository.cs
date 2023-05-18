using GraphqlDomain.Models.Domain.IRD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphqlDomain.Contract
{
    public interface IIRDRepository
    {
        public List<IRDResponse> GenerateTaxNumbers(IRDRequest request);
    }
}
