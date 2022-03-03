using DomainModel.CQRS.Commands.AnagraficaMissioni.InserimentoMissione;
using DomainModel.CQRS.Queries.CausaliMissione;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Common
{
    public interface IDbMethods
    {
        public int Count();
        public List<GetCausaleMissioneQueryResult> elencoCausaliMissione();
        public void NuovaMissione(AddMissioneCommand missione);
    }
}
