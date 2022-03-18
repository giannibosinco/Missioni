using CQRS.Queries;
using DomainModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.TipologieMissioni
{
    public class GetTipologieMissioniQueryHandler : IQueryHandler<GetTipologieMissioniQuery, List<GetTipologieMissioniQueryResult>>
    {
        private readonly IDbMethods serviziPersistenza;

        public GetTipologieMissioniQueryHandler(IDbMethods serviziPersistenza)
        {
            this.serviziPersistenza = serviziPersistenza;
        }

        public List<GetTipologieMissioniQueryResult> Handle(GetTipologieMissioniQuery qry)
        {
            return serviziPersistenza.elencoTipologieMissioni();
        }
    }
}
