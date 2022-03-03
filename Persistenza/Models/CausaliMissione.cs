using System;
using System.Collections.Generic;

#nullable disable

namespace Persistenza.Models
{
    public partial class CausaliMissione
    {
        public CausaliMissione()
        {
            Missionis = new HashSet<Missioni>();
        }

        public long IdCausaliMissione { get; set; }
        public string DescCausaleMissione { get; set; }
        public char? TipoMissione { get; set; }
        public DateTime? DtIns { get; set; }
        public string User { get; set; }

        public virtual ICollection<Missioni> Missionis { get; set; }
    }
}
