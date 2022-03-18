using CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.TipologieMissioni
{
    public class GetTipologieMissioniQuery : IQuery<List<GetTipologieMissioniQueryResult>>
    {
    }
}
