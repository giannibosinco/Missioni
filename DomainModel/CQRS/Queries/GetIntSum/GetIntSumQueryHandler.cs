using System;
using System.Collections.Generic;
using System.Text;
using CQRS.Queries;
using DomainModel.Common;

namespace DomainModel.CQRS.Queries.GetIntSum
{
    public class GetIntSumQueryHandler : IQueryHandler<GetIntSumQuery, int>
    {
        private readonly IDbMethods serviziPersistenza;

        public GetIntSumQueryHandler(IDbMethods serviziPersistenza)
        {
            this.serviziPersistenza = serviziPersistenza ?? throw new ArgumentNullException(nameof(serviziPersistenza));
        }

        public int Handle(GetIntSumQuery query)
        {
            var res = serviziPersistenza.Count();

            return query.First + query.Second;
        }
    }
}
