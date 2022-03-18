using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissioniBE.DTO
{
    public class AddMissioniDipendentiCommand_DTO
    {
        public Guid IdMissioneDipendente { get; set; }
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
    }
}
