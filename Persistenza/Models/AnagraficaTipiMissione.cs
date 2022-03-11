using System;
using System.Collections.Generic;

#nullable disable

namespace Persistenza.Models
{
    public partial class AnagraficaTipiMissione
    {
        public Guid IdAnagraficaTipiMissione { get; set; }
        public Guid? CodSedeMissione { get; set; }
        public string DescrizioneMissione { get; set; }
        public bool CapoTurno { get; set; }
        public long? IdTipologiaMissione { get; set; }
        public int? CodEvento { get; set; }
        public DateTime DtInizioValidita { get; set; }
        public DateTime? DtFineValidita { get; set; }
        public DateTime? DtIns { get; set; }
        public string User { get; set; }
    }
}
