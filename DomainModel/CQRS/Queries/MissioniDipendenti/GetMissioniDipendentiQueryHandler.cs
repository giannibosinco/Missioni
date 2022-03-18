using CQRS.Queries;
using DomainModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.MissioniDipendenti
{
     public  class GetMissioniDipendentiQueryHandler : IQueryHandler<GetMissioniDipendentiQuery, List<GetMissioniDipendentiQueryResult>>
    {
        private readonly IDbMethods serviziPersistenza;

        public GetMissioniDipendentiQueryHandler(IDbMethods serviziPersistenza)
        {
            this.serviziPersistenza = serviziPersistenza;
        }

        public List<GetMissioniDipendentiQueryResult> Handle(GetMissioniDipendentiQuery qry)
        {
            return serviziPersistenza.elencoMissioniDipendenti();
        }
    }
}
