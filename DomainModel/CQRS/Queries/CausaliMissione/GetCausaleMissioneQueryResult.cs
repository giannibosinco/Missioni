using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.CausaliMissione
{
    public class GetCausaleMissioneQueryResult
    {
        public long IdCausaliMissione { get; set; }
        public string DescCausaleMissione { get; set; }
        public char? TipoMissione { get; set; }

    }
}
