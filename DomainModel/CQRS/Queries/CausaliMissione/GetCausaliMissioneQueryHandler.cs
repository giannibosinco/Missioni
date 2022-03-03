using CQRS.Queries;
using DomainModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.CausaliMissione
{
    public class GetCausaliMissioneQueryHandler : IQueryHandler<GetCausaleMissioneQuery, List<GetCausaleMissioneQueryResult>>
    {
        private readonly IDbMethods serviziPersistenza;

        public GetCausaliMissioneQueryHandler(IDbMethods serviziPersistenza)
        {
            this.serviziPersistenza = serviziPersistenza ?? throw new ArgumentNullException(nameof(serviziPersistenza));
        }

        public List<GetCausaleMissioneQueryResult> Handle(GetCausaleMissioneQuery qry)
        {
            return serviziPersistenza.elencoCausaliMissione();
        }
    }
}
