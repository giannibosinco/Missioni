using System;
using System.Collections.Generic;

#nullable disable

namespace Persistenza.Models
{
    public partial class MissioniTransiti
    {
        public Guid IdMissione { get; set; }
        public Guid IdDipendente { get; set; }
        public Guid IdTransito { get; set; }
        public DateTime DtInizioValidita { get; set; }
        public DateTime? DtFineValidita { get; set; }
        public DateTime? DtIns { get; set; }
        public string User { get; set; }

        public virtual MissioniDipendenti Id { get; set; }
    }
}
