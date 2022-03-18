using CQRS.Queries;
using DomainModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.Missioni
{
    public class GetMissioniQueryHandler : IQueryHandler<GetMissioniQuery, List<GetMissioniQueryResult>>
    {
        private readonly IDbMethods serviziPersistenza;
        public GetMissioniQueryHandler(IDbMethods serviziPersistenza)
        {
            this.serviziPersistenza = serviziPersistenza;
        }

        public List<GetMissioniQueryResult> Handle(GetMissioniQuery qry)
        {
            return serviziPersistenza.elencoMissioni();
        }
    }
}
