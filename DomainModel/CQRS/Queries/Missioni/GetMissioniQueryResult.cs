using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.Missioni
{
    public class GetMissioniQueryResult
    {
        public Guid IdMissione { get; set; }
        public Guid? CodSedeMissione { get; set; }
        public DateTime DataOraInizioMissione { get; set; }
        public DateTime DataOraFineMissione { get; set; }
        public string LocalitaPartenza { get; set; }
        public string LocalitaDestinazione { get; set; }
        public string MotivoMissione { get; set; }
        public string MezziTrasporto { get; set; }
        public string EstremiAutorizzazione { get; set; }
        public string IdTipologiaMissione { get; set; }
        public long? CodEvento { get; set; }
        public bool FlProv { get; set; }
        public bool? FlSedeVvf { get; set; }
        public long? IdCausaliMissione { get; set; }
        public DateTime? DataInizioMissione { get; set; }
    }
}
