using System;
using System.Collections.Generic;

#nullable disable

namespace Persistenza.Models
{
    public partial class MissioniDipendenti
    {
        public MissioniDipendenti()
        {
            MissioniTransitis = new HashSet<MissioniTransiti>();
        }

        public Guid IdMissione { get; set; }
        public Guid IdDipendente { get; set; }
        public string CodFiscale { get; set; }
        public string IdMansione { get; set; }
        public DateTime DataOraPartitoSede { get; set; }
        public DateTime DataOraArrivatoSede { get; set; }
        public bool? FLavorato { get; set; }
        public DateTime DtInizioValidita { get; set; }
        public DateTime? DtFineValidita { get; set; }
        public DateTime? DtIns { get; set; }
        public string User { get; set; }

        public virtual Missioni IdMissioneNavigation { get; set; }
        public virtual ICollection<MissioniTransiti> MissioniTransitis { get; set; }
    }
}
