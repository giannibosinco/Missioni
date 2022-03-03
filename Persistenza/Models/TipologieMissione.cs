using System;
using System.Collections.Generic;

#nullable disable

namespace Persistenza.Models
{
    public partial class TipologieMissione
    {
        public TipologieMissione()
        {
            Missionis = new HashSet<Missioni>();
        }

        public string IdTipologiaMissione { get; set; }
        public string DescrTipMissione { get; set; }
        public string VistiConTransiti { get; set; }
        public DateTime? DtIns { get; set; }
        public string User { get; set; }

        public virtual ICollection<Missioni> Missionis { get; set; }
    }
}
