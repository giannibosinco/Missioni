using CQRS.Queries;
using DomainModel.CQRS.Queries.Missioni;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.MissioniDipendenti
{
    public class GetMissioniDipendentiQuery : IQuery<List<GetMissioniDipendentiQueryResult>>
    {
    }
}
