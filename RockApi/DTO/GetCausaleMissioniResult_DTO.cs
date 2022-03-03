using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissioniBE.DTO
{
    public class GetCausaleMissioniResult_DTO
    {
        public long IdCausaliMissione { get; set; }
        public string DescCausaleMissione { get; set; }
        public char? TipoMissione { get; set; }

    }
}
