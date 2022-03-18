using DomainModel.CQRS.AnagraficaMissioniDipendenti;
using DomainModel.CQRS.Commands.AnagraficaMissioni.InserimentoMissione;
using DomainModel.CQRS.Queries.CausaliMissione;
using DomainModel.CQRS.Queries.Missioni;
using DomainModel.CQRS.Queries.MissioniDipendenti;
using DomainModel.CQRS.Queries.TipologieMissioni;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Common
{
    public interface IDbMethods
    {
      
        public int Count();
        public List<GetCausaleMissioneQueryResult> elencoCausaliMissione();
        public void NuovaMissioniDipendenti(AddMissioniDipendentiCommand command);
        public void NuovaMissione(AddMissioneCommand missione);
        public List<GetTipologieMissioniQueryResult> elencoTipologieMissioni();
        public List<GetMissioniQueryResult> elencoMissioni();
        public List<GetMissioniDipendentiQueryResult> elencoMissioniDipendenti();
    }
}
